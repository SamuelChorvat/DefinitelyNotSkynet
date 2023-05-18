using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkyNotes.Common.EntityModels.Sqlite {
    public class Note {

        public Note(string relatesTo, string noteText, string ticketId = "N/A") {
            CreatedAt = DateTime.Now;
            RelatesTo = relatesTo;
            TicketId = ticketId;
            NoteText = noteText;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(32)]
        public string RelatesTo { get; set; }

        [StringLength(32)]
        public string TicketId { get; set; }

        [Required]
        public string NoteText { get; set; }
    }
}