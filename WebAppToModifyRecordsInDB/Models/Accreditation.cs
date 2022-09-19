using System.ComponentModel.DataAnnotations;

namespace WebAppToModifyRecordsInDB.Models
{
    public class Accreditation
    {
        [Key]
        public int AccreditationId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public DateTime Expires { get; set; } = DateTime.Now;

        public virtual Status? Status { get; set; }
    }
}
