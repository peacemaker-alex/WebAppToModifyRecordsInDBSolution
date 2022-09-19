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
        public string Expires { get; set; }

        public virtual Status? Status { get; set; }
    }
}
