using FlightManagement.Model.Plane;
using FlightManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : BaseController
    {
        private IPlaneServices _planeServices;
        public PlaneController(IPlaneServices planeServices)
        {
            _planeServices = planeServices;
        }
        [HttpPost]
        public async Task<PlaneCreateResponse> Create(PlaneCreateRequest planeCreateRequest)
        {
            return await _planeServices.CreatePlane(planeCreateRequest);
        }
        [HttpGet]
        public async Task<IEnumerable<PlaneGetResponse>> GetAll()
        {
            return await _planeServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<PlaneGetResponse> GetById(int Id)
        {
            return await _planeServices.GetById(Id);
        }
        [HttpPut("{Id}")]
        public async Task<PlaneUpdateResponse> Update(int Id,PlaneUpdateRequest planeUpdateRequest)
        {
            return await _planeServices.UpdatePlane(Id, planeUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool>DeletePlane(int Id)
        {
           return await _planeServices.DeletePlane(Id);
        }
    }
}
