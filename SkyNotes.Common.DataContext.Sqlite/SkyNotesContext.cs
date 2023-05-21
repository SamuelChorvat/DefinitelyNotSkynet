using Microsoft.EntityFrameworkCore;
using SkyNotes.Common.EntityModels.Sqlite;

namespace SkyNotes.Common.DataContext.Sqlite
{
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
                string dir = Environment.CurrentDirectory;
                string path = string.Empty;

                if (dir.EndsWith("net7.0"))
                {
                    // Running in the <project>\bin\<Debug|Release>\net7.0 directory.
                    path = Path.Combine("..", "..", "..", "..", "SkyNote.db");
                }
                else
                {
                    // Running in the <project> directory.
                    path = Path.Combine("..", "SkyNote.db");
                }

                optionsBuilder.UseSqlite($"Filename={path}");
            }
        }
    }
}