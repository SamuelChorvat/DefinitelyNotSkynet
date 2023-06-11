using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyNotes.Common.EntityModels.SqlServer;

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

        
    [Display(Name = "Relates To")]
    [Required(ErrorMessage = "The Relates To field is required.")]
    [StringLength(32)] 
    public string? RelatesTo { get; set; }

    [StringLength(32)] public string? TicketId { get; set; }

    [Required(ErrorMessage = "The Content field is required.")]
    [Display(Name = "Content")] 
    public string? NoteText { get; set; }

    public override string ToString() {
        return $"Created At: {CreatedAt} --- " +
               $"Relates To: {RelatesTo} --- " +
               $"Ticket Id: {TicketId} --- " +
               $"Note Text: {NoteText}";
    }
}