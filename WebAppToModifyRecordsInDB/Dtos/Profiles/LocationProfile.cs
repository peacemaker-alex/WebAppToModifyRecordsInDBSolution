using AutoMapper;
using WebAppToModifyRecordsInDB.Contracts.Dtos;
using WebAppToModifyRecordsInDB.Models;

namespace WebAppToModifyRecordsInDB.Dtos.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            // Source -> Target (or Destination)
            CreateMap<Location, LocationDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Accreditation, AccreditationDto>();
            CreateMap<Status, StatusDto>();
            CreateMap<TrackType, TrackTypeDto>();

            CreateMap<LocationDto, Location>();
            CreateMap<AddressDto, Address>();
            CreateMap<AccreditationDto, Accreditation>();
            CreateMap<StatusDto, Status>();
            CreateMap<TrackTypeDto, TrackType>();
        }
    }
}
