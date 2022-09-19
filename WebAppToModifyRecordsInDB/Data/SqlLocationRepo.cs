using Microsoft.EntityFrameworkCore;
using WebAppToModifyRecordsInDB.Models;

namespace WebAppToModifyRecordsInDB.Data
{
    public class SqlLocationRepo : ILocationRepo
    {
        private readonly Context _context;

        public SqlLocationRepo(Context context)
        {
            _context = context;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<TrackType>> GetTrackTypes() => await _context.TrackTypes.ToListAsync();

        public async Task<List<Status>> GetStatuses() => await _context.Statuses.ToListAsync();

        public async Task<List<Location>> GetAllLocations()
        {
            // Eager loading
            return await _context.Locations
                .Include(location => location.Address)
                .Include(location => location.Accreditation)
                .Include(location => location.Accreditation.Status)
                .Include(location => location.TrackType)
                .ToListAsync();
        }

        public async Task<Location> GetLocation(int id)
        {
            // Explicit loading
            var location = await _context.Locations
                .SingleOrDefaultAsync(location => location.Id == id);

            if (location != null)
            {
                await _context.TrackTypes
                    .Where(trackType => trackType.Id == location.TrackTypeId)
                    .LoadAsync();

                await _context.Addresses
                    .Where(address => address.AddressId == location.AddressId)
                    .LoadAsync();

                await _context.Accreditations
                    .Where(accreditation => accreditation.AccreditationId == location.AccreditationId)
                    .LoadAsync();

                await _context.Statuses
                    .Where(status => status.Id == location.Accreditation.StatusId)
                    .LoadAsync();
            }

            return location;
        }

        public async void CreateLocation(Location location) => await _context.Locations.AddAsync(location);

        public void UpdateLocation(Location location) { /* Nothing */ }

        public async void DeleteLocation(Location location)
        {
            int accreditationId = location.AccreditationId;
            int addressId = location.AddressId;

            Accreditation accreditation = await _context.Accreditations.SingleAsync(a => a.AccreditationId == accreditationId);
            Address address = await _context.Addresses.SingleAsync(a => a.AddressId == addressId);

            _context.Remove(accreditation);
            _context.Remove(address);    
            _context.Locations.Remove(location);
        }
    }
}
