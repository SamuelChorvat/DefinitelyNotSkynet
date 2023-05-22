using Microsoft.EntityFrameworkCore;
using SkyNotes.Common.DataContext.Sqlite;
using SkyNotes.Common.EntityModels.Sqlite;

namespace SkyNotes.BlazorServer.Data;

public class SkyNotesService : ISkyNotesService
{
    private readonly SkyNotesContext _dbContext;

    public SkyNotesService(SkyNotesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Note>> GetNotesAsync()
    {
        return _dbContext.Notes.OrderByDescending(x => x.CreatedAt).ToListAsync();
    }

    public Task<Note> CreateNoteAsync(Note note)
    {
        if (string.IsNullOrEmpty(note.TicketId)) note.TicketId = "N/A";
        _dbContext.Notes.Add(note);
        _dbContext.SaveChangesAsync();
        return Task.FromResult(note);
    }
}