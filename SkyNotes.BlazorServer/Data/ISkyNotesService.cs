using SkyNotes.Common.EntityModels.SqlServer;

namespace SkyNotes.BlazorServer.Data;

public interface ISkyNotesService
{
    Task<List<Note>> GetNotesAsync();
    Task<List<Note>> GetNotesAsync(DateTime from, DateTime to);
    Task<Note?> GetNoteAsync(int id);
    Task<Note> CreateNoteAsync(Note note);
    Task<Note> UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(int id);
}