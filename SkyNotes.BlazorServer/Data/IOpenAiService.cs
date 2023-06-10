namespace SkyNotes.BlazorServer.Data; 

public interface IOpenAiService {
    Task<string> QueryNotes(DateTime from, DateTime to, string query);
}