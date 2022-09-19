using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppToModifyRecordsInDB.Contracts.Dtos;
using WebAppToModifyRecordsInDB.Data;
using WebAppToModifyRecordsInDB.Models;

namespace WebAppToModifyRecordsInDB.Controllers
{
    /// <summary>
    /// Locations controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepo _repository;
        private readonly IMapper _mapper;

        public LocationsController(ILocationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Return all types.
        /// </summary>
        /// <returns>Collection of types.</returns>
        [HttpGet("types")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TrackTypeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TrackType>>> GetTrackTypes()
        {
            try
            {
                var types = await _repository.GetTrackTypes();

                if (types == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No any type in db.");
                }

                return Ok(_mapper.Map<List<TrackTypeDto>>(types));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the db.");
            }
        }

        /// <summary>
        /// Return all statuses.
        /// </summary>
        /// <returns>Collection of statuses.</returns>
        [HttpGet("statuses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StatusDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Status>>> GetStatuses()
        {
            try
            {
                var statuses = await _repository.GetStatuses();

                if (statuses == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No any status in db.");
                }

                return Ok(_mapper.Map<List<StatusDto>>(statuses));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the db.");
            }
        }

        /// <summary>
        /// Return all locations.
        /// </summary>
        /// <returns>Collection of locations.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LocationDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<LocationDto>>> GetAllLocations()
        {
            try
            {
                var locations = await _repository.GetAllLocations();

                if (locations == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No any records in db.");
                }

                return Ok(_mapper.Map<List<LocationDto>>(locations));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the db.");
            }
        }

        /// <summary>
        /// Return location by id.
        /// </summary>
        /// <param name="id">Location id.</param>
        /// <returns>Return location by specified id.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LocationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LocationDto>> GetLocation(int id)
        {
            var location = await _repository.GetLocation(id);

            if (location != null)
            {
                return Ok(_mapper.Map<LocationDto>(location));
            }

            return NotFound($"Record with such id={id} was not found in db.");
        }

        /// <summary>
        /// Create new location.
        /// </summary>
        /// <param name="locationDto">Location request.</param>
        /// <returns>Collection of locations.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LocationDto>))]
        public async Task<ActionResult<List<LocationDto>>> CreateLocation(LocationDto locationDto)
        {
            locationDto.TrackType = null;
            locationDto.Accreditation.Status = null;
            var location = _mapper.Map<Location>(locationDto);

            _repository.CreateLocation(location);
            await _repository.SaveChangesAsync();

            return Ok(_mapper.Map<List<LocationDto>>(await _repository.GetAllLocations()));
        }

        /// <summary>
        /// Update location.
        /// </summary>
        /// <param name="id">Location id.</param>
        /// <param name="updatedLocation">Updated location request.</param>
        /// <returns>Collection of locations.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LocationDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<LocationDto>>> UpdateLocation(int id, LocationDto updatedLocation)
        {
            var location = await _repository.GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }

            location.LocationId = updatedLocation.LocationId;
            location.TrackCode = updatedLocation.TrackCode;
            location.TrackTypeId = updatedLocation.TrackTypeId;
            location.Name = updatedLocation.Name;
            location.Email = updatedLocation.Email;
            location.Phone = updatedLocation.Phone;
            location.WebSite = updatedLocation.WebSite;

            location.Address.Street = updatedLocation.Address.Street;
            location.Address.City = updatedLocation.Address.City;
            location.Address.State = updatedLocation.Address.State;
            location.Address.ZipPostalCode = updatedLocation.Address.ZipPostalCode;
            location.Address.Country = updatedLocation.Address.Country;

            location.Accreditation.StatusId = updatedLocation.Accreditation.StatusId;
            location.Accreditation.Expires = updatedLocation.Accreditation.Expires;

            _repository.UpdateLocation(location);
            await _repository.SaveChangesAsync();

            return Ok(_mapper.Map<List<LocationDto>>(await _repository.GetAllLocations()));
        }

        /// <summary>
        /// Delete location.
        /// </summary>
        /// <param name="id">Location id.</param>
        /// <returns>Collection of locations.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LocationDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<LocationDto>>> DeleteLocation(int id)
        {
            var location = await _repository.GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }

            _repository.DeleteLocation(location);
            await _repository.SaveChangesAsync();

            return Ok(_mapper.Map<List<LocationDto>>(await _repository.GetAllLocations()));
        }
    }
}
