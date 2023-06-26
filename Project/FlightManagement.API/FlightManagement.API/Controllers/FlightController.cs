using FlightManagement.Model.Flight;
using FlightManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : BaseController
    {
        private IFlightServices _flightServices;
        public FlightController(IFlightServices flightServices)
        {
            _flightServices = flightServices;
        }
        [HttpPost]
        public async Task<FlightCreateRespone> Create(FlightCreateRequest flightCreateRequest)
        {
            return await _flightServices.CreateFlight(flightCreateRequest);
        }
        [HttpGet]
        public async Task<IEnumerable<FlightGetRespone>> GetAll()
        {
            return await _flightServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<FlightGetRespone> GetById(int Id)
        {
            return await _flightServices.GetById(Id);
        }
        [HttpPut("{Id}")]
        public async Task<FlightUpdateResponse> Update(int Id,FlightUpdateRequest flightUpdateRequest)
        {
            return await _flightServices.UpdateFlight(Id, flightUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public  async Task<bool>Delete(int Id)
        {
            return await _flightServices.DeleteFlight(Id);
        }
        [HttpPost("FlightByAirport")]
        public async Task<IEnumerable<FlightGetRespone>> FlightByAirport(FlightByAirportRequest flightByAirportRequest)
        {
            return await _flightServices.GetFlightByAirport(flightByAirportRequest);
        }


    }
}
