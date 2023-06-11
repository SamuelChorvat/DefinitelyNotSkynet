using System.Diagnostics;
using System.Text;
using Azure;
using Azure.AI.OpenAI;
using SkyNotes.Common.EntityModels.SqlServer;

namespace SkyNotes.BlazorServer.Data; 

public class OpenAiService : IOpenAiService {
    
    private readonly ISkyNotesService _skyNotesService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OpenAiService> _logger;

    public OpenAiService(ISkyNotesService skyNotesService, IConfiguration configuration, 
        ILogger<OpenAiService> logger) {
        _skyNotesService = skyNotesService;
        _configuration = configuration;
        _logger = logger;
    }
    
    public async Task<string> QueryNotes(DateTime from, DateTime to, string query) {
        List<Note> notes = await _skyNotesService.GetNotesAsync(from, to);
        if (notes.Count == 0) {
            return "You have no notes in that date range!";
        }
        
        string notesJoined = string.Join("\n", notes.Select(note => note.ToString()));
        
        _logger.LogInformation($"Querying {notes.Count} notes");
        string glueStatement = "\n\nUse the above notes to answer the below query/question\n\n";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string queryResponse =  await QueryOpenAi(notesJoined + glueStatement + query);
        stopwatch.Stop();
        return $"Queried {notes.Count} notes in {stopwatch.ElapsedMilliseconds/1000} seconds\n\n {queryResponse}";
    }

    private async Task<string> QueryOpenAi(string query) {
        OpenAIClient client = new OpenAIClient(
            new Uri("https://skynotes-ai.openai.azure.com/"),
            new AzureKeyCredential(_configuration["OPEN_AI_KEY"]!));

        Response<Completions> completionsResponse = await client.GetCompletionsAsync(
            deploymentOrModelName: "skynotes-davinci",
            new CompletionsOptions()
            {
                Prompts = { query },
                Temperature = (float)1,
                MaxTokens = (int?) (4000 - Math.Round(query.Length/4d) - 200),
                NucleusSamplingFactor = (float)1,
                FrequencyPenalty = (float)0,
                PresencePenalty = (float)0,
                GenerationSampleCount = 1,
            });
        Completions completions = completionsResponse.Value;

        return string.Join("\n", completions.Choices.Select(x => x.Text)).Trim();
    }
}