namespace WebAppToModifyRecordsInDB.Web.Services
{
    public interface ILocationService
    {
        List<LocationDto> Locations { get; set; }
        List<StatusDto> Statuses { get; set; }
        List<TrackTypeDto> TrackTypes { get; set; }

        Task GetTrackTypes();
        Task GetStatuses();
        Task GetAllLocations();
        Task<LocationDto> GetLocation(int id);
        Task CreateLocation(LocationDto locationDto);
        Task UpdateLocation(LocationDto locationDto);
        Task DeleteLocation(int id);
    }
}
