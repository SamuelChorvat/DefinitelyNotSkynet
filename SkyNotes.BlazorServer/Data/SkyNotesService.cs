﻿using Microsoft.EntityFrameworkCore;
using SkyNotes.Common.DataContext.SqlServer;
using SkyNotes.Common.EntityModels.SqlServer;

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

    public Task<List<Note>> GetNotesAsync(DateTime from, DateTime to) {
        return _dbContext.Notes.Where(x => x.CreatedAt >= from && x.CreatedAt <= to).ToListAsync();
    }

    public Task<Note?> GetNoteAsync(int id)
    {
        return _dbContext.Notes.FirstOrDefaultAsync(n => n.NoteId == id);
    }

    public Task<Note> CreateNoteAsync(Note note)
    {
        if (string.IsNullOrEmpty(note.TicketId)) note.TicketId = "N/A";
        _dbContext.Notes.Add(note);
        _dbContext.SaveChangesAsync();
        return Task.FromResult(note);
    }

    public Task<Note> UpdateNoteAsync(Note note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
        _dbContext.SaveChangesAsync();
        return Task.FromResult(note);
    }

    public Task DeleteNoteAsync(int id)
    {
        Note? note = _dbContext.Notes.FirstOrDefaultAsync(n => n.NoteId == id).Result;

        if (note == null)
        {
            return Task.CompletedTask;
        }
        else
        {
            _dbContext.Notes.Remove(note);
            return _dbContext.SaveChangesAsync();
        }
    }
}