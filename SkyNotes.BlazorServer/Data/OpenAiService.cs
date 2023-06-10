using Azure;
using Azure.AI.OpenAI;

namespace SkyNotes.BlazorServer.Data; 

public class OpenAiService : IOpenAiService {
    
    private readonly ISkyNotesService _skyNotesService;
    private readonly IConfiguration _configuration;

    public OpenAiService(ISkyNotesService skyNotesService, IConfiguration configuration) {
        _skyNotesService = skyNotesService;
        _configuration = configuration;
    }
    
    public async Task<string> QueryNotes(DateTime from, DateTime to, string query) {
        throw new NotImplementedException();
    }

    private async Task<string> QueryOpenAi(string query) {
        OpenAIClient client = new OpenAIClient(
            new Uri("https://skynotes-ai.openai.azure.com/"),
            new AzureKeyCredential(_configuration["OPEN_AI_KEY"]!));
        
        Response<Completions> completionsResponse = await client.GetCompletionsAsync(
            deploymentOrModelName: "skynotes-davinci",
            new CompletionsOptions()
            {
                Prompts = { "What color is apple?" },
                Temperature = (float)1,
                MaxTokens = 4000,
                NucleusSamplingFactor = (float)1,
                FrequencyPenalty = (float)0,
                PresencePenalty = (float)0,
                GenerationSampleCount = 1,
            });
        Completions completions = completionsResponse.Value;

        return completions.ToString()!;
    }
}