using SkyNotes.Common.EntityModels.Sqlite;

namespace SkyNotes.BlazorServer.Data;

public interface ISkyNotesService
{
    Task<List<Note>> GetNotesAsync();
}