using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppToModifyRecordsInDB.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LocationId { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public string TrackCode { get; set; }
        [Required]
        public int TrackTypeId { get; set; }
        [Required]
        public int AccreditationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string WebSite { get; set; }

        [ForeignKey("AddressId")]
        [Required]
        public virtual Address Address { get; set; }

        [ForeignKey("AccreditationId")]
        [Required]
        public virtual Accreditation Accreditation { get; set; }

        public virtual TrackType? TrackType { get; set; }
    }
}
