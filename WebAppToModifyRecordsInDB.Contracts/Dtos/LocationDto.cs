using System.ComponentModel.DataAnnotations;

namespace WebAppToModifyRecordsInDB.Contracts.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string LocationId { get; set; }
        public string TrackCode { get; set; }
        public int TrackTypeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }

        public virtual AddressDto Address { get; set; }
        public virtual AccreditationDto Accreditation { get; set; }
        public virtual TrackTypeDto? TrackType { get; set; }

    }
}
