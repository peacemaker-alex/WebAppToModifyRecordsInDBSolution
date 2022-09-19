using WebAppToModifyRecordsInDB.Models;

namespace WebAppToModifyRecordsInDB.Data
{
    public interface ILocationRepo
    {
        Task SaveChangesAsync();
        Task<List<TrackType>> GetTrackTypes();
        Task<List<Status>> GetStatuses();
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocation(int id);
        void CreateLocation(Location? location);
        void UpdateLocation(Location? location);
        void DeleteLocation(Location? location);
    }
}
