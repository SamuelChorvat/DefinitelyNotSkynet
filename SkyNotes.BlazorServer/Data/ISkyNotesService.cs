using SkyNotes.Common.EntityModels.Sqlite;

namespace SkyNotes.BlazorServer.Data;

public interface ISkyNotesService
{
    Task<List<Note>> GetNotesAsync();
    Task<Note?> GetNoteAsync(int id);
    Task<Note> CreateNoteAsync(Note note);
    Task<Note> UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(int id);
}