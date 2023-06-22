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
                    NamePlane = PlaneRequest.NamePlane,
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

        public async Task<bool> DeletePlane(int id)
        {
            var plane = _planeRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
            if (plane != null)
            {
                _planeRepository.Delete(plane);
                _planeRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<List<PlaneGetResponse>> GetAll()
        {
            var listplane = _planeRepository.FindAll().Select(c => new PlaneGetResponse
            {
                Id = c.Id,
                NamePlane = c.NamePlane,
            }).ToList();
            return await Task.FromResult(listplane);
        }

        public async Task<PlaneGetResponse> GetById(int id)
        {
            var plane = _planeRepository.FindByCondition(c => c.Id == id).Select(c => new PlaneGetResponse
            {
                Id = c.Id,
                NamePlane = c.NamePlane,
            }).FirstOrDefault();
            return await Task.FromResult(plane);

        }

        public async Task<PlaneUpdateResponse> UpdatePlane(int id, PlaneUpdateRequest PlaneRequest)
        {
            if (id > 0)
            {
                var diArrivalAirport = _planeRepository.FindByCondition(c => c.Id == id).FirstOrDefault();
                if (diArrivalAirport != null)
                {
                    var plane = new Plane
                    {
                        Id = id,
                        NamePlane = PlaneRequest.NamePlane,
                    };
                    _planeRepository.Update(plane);
                    _planeRepository.SaveChanges();

                    var planeResponse = new PlaneUpdateResponse
                    {
                        Id = plane.Id,
                        NamePlane = plane.NamePlane,
                    };
                    return await Task.FromResult(planeResponse);
                }
                return new PlaneUpdateResponse();

            }
            else
            {
                return new PlaneUpdateResponse();
            }
        }
    }
}

