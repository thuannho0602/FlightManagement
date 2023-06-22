using FlightManagement.Model.ArrivalAirport;
using FlightManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalAirportController : BaseController
    {
        private  IArrivalAirportServices _arrivalAirportServices;
        public ArrivalAirportController(IArrivalAirportServices arrivalAirportServices)
        {
            _arrivalAirportServices = arrivalAirportServices;
        }
        [HttpPost]
        public async Task<ArrivalAirportCreateResponse> Create(ArrivalAirportCreateRequest arrivalAirportCreateRequest)
        {
            return await _arrivalAirportServices.CreateArrivalAirport(arrivalAirportCreateRequest);
        }
        [HttpGet]
        public async Task<IEnumerable<ArrivalAirportGetResponse>> GetAll()
        {
            return await _arrivalAirportServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<ArrivalAirportGetResponse> GetById(int Id)
        {
            return await _arrivalAirportServices.GetById(Id);
        }
        [HttpPut("{Id}")]
        public async Task<ArrivalAirportUpdateResponse> Update(int Id,ArrivalAirportUpdateRequest arrivalAirportUpdateRequest)
        {
            return await _arrivalAirportServices.UpdateArrivalAirport(Id, arrivalAirportUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool>Delete(int Id)
        {
            return await _arrivalAirportServices.DeleteArrivalAirport(Id);
        }
    }
}
