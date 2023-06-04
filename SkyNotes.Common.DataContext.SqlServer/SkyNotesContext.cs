using Microsoft.EntityFrameworkCore;
using SkyNotes.Common.EntityModels.SqlServer;

namespace SkyNotes.Common.DataContext.SqlServer;

public class SkyNotesContext : DbContext
{
    public SkyNotesContext()
    {
    }

    public SkyNotesContext(DbContextOptions<SkyNotesContext> options) : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("DEFAULT CONNECTION STRING");
        }
    }
    
}