using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyNotes.Common.EntityModels.Sqlite
{
    public class Note
    {
        public Note()
        {
            CreatedAt = DateTime.Now;
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        [Required] public DateTime CreatedAt { get; set; }

        [Required] [StringLength(32)] public string? RelatesTo { get; set; }

        [StringLength(32)] public string? TicketId { get; set; }

        [Required] public string? NoteText { get; set; }
    }
}