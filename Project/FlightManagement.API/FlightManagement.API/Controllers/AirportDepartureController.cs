using FlightManagement.Model.AirportDeparture;
using FlightManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportDepartureController : BaseController
    {
        private IAirportDepartureServices _airportDepartureServices;
        public AirportDepartureController(IAirportDepartureServices airportDepartureServices)
        {
            _airportDepartureServices = airportDepartureServices;
        }
        [HttpPost]
        public async Task<AirportDepartureCreateResponse> Create(AirportDepartureCreateRequest airportDepartureCreateRequest)
        {
            return await _airportDepartureServices.CreateAirportDeparture(airportDepartureCreateRequest);
        }
        [HttpGet]
        public async Task<IEnumerable<AirportDepartureGetReponse>> GetAll()
        {
            return await _airportDepartureServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<AirportDepartureGetReponse> GetById(int Id)
        {
            return await _airportDepartureServices.GetById(Id);
        }
        [HttpPut("{Id}")]
        public async Task<AirportDepartureUpdateResponse> Update(int Id,AirportDepartureUpdateRequest airportDepartureUpdateRequest)
        {
            return await _airportDepartureServices.UpdateAirportDeparture(Id,airportDepartureUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool>Delete(int Id)
        {
            return await _airportDepartureServices.DeleteAirportDeparture(Id);
        }

    }
}
