using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.Plane;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class PlaneServices : IPlaneServices
    {
        private readonly IPlaneRepository _planeRepository;
        private readonly ApplicationDbContext _appDbContext;
        public PlaneServices(IPlaneRepository planeRepository, ApplicationDbContext appDbContext)
        {
            _planeRepository = planeRepository;
            _appDbContext = appDbContext;
        }

        public async Task<PlaneCreateResponse> CreatePlane(PlaneCreateRequest PlaneRequest)
        {
            if (PlaneRequest.Id == 0)
            {
                var plane = new Plane
                {
                    NamePlane= PlaneRequest.NamePlane,
                };
                _planeRepository.Add(plane);
                _planeRepository.SaveChanges();

                var planeResponse = new PlaneCreateResponse
                {
                    Id = plane.Id,
                    NamePlane = PlaneRequest.NamePlane,
                };
                return await Task.FromResult(planeResponse);
            }
            else
            {
                return new PlaneCreateResponse();
            }
        }

        public Task<bool> DeletePlane(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlaneGetResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PlaneGetResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlaneUpdateResponse> UpdatePlane(PlaneUpdateRequest PlaneRequest)
        {
            throw new NotImplementedException();
        }
    }
}
