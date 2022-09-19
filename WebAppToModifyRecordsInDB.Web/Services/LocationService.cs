using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace WebAppToModifyRecordsInDB.Web.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public LocationService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<LocationDto> Locations { get; set; } = new ();
        public List<StatusDto> Statuses { get; set; } = new ();
        public List<TrackTypeDto> TrackTypes { get; set; } = new ();

        public async Task GetTrackTypes()
        {
            try
            {
                var results = await _httpClient.GetFromJsonAsync<List<TrackTypeDto>>("api/locations/types");

                if (results != null)
                {
                    TrackTypes = results;
                }
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
                Console.WriteLine(exception);
                
                throw;
            }
        }

        public async Task GetStatuses()
        {
            try
            {
                var results = await _httpClient.GetFromJsonAsync<List<StatusDto>>("api/locations/statuses");

                if (results != null)
                {
                    Statuses = results;
                }
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
                Console.WriteLine(exception);
                
                throw;
            }
        }

        public async Task GetAllLocations()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<LocationDto>>("api/locations");

                if (result != null)
                {
                    Locations = result;
                }
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
                Console.WriteLine(exception);

                throw;
            }
        }

        public async Task<LocationDto> GetLocation(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<LocationDto>($"api/locations/{id}");

                if (result != null)
                {
                    return result;
                }

                throw new Exception("Location not found.");
            }
            catch (Exception exception)
            {
                // TODO: Add logging here
                Console.WriteLine(exception);
                
                throw;
            }
        }

        public async Task CreateLocation(LocationDto locationDto)
        {
            try
            {
                await SetLocations(await _httpClient.PostAsJsonAsync("api/locations", locationDto));
            }
            catch (Exception exception)
            {
                // TODO:Add logging here
                Console.WriteLine(exception);

                throw;
            }
        }

        public async Task UpdateLocation(LocationDto locationUpdateDto)
        {
            try
            {
                await SetLocations(await _httpClient.PutAsJsonAsync($"api/locations/{locationUpdateDto.Id}", locationUpdateDto));
            }
            catch (Exception exception)
            {
                // TODO:Add logging here
                Console.WriteLine(exception);

                throw;
            }
        }

        public async Task DeleteLocation(int id)
        {
            try
            {
                await SetLocations(await _httpClient.DeleteAsync($"api/locations/{id}"));
            }
            catch (Exception exception)
            {
                // TODO:Add logging here
                Console.WriteLine(exception);

                throw;
            }
        }

        private async Task SetLocations(HttpResponseMessage httpResponseMessage)
        {
            Locations = await httpResponseMessage.Content.ReadFromJsonAsync<List<LocationDto>>();

            _navigationManager.NavigateTo("AllLocations");
        }
    }
}
