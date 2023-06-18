using FlightManagement.Model.Plane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services
{
    public interface IPlaneServices
    {
        Task<List<PlaneGetResponse>> GetAll();
        Task<PlaneGetResponse> GetById(int id);
        Task<PlaneCreateResponse> CreatePlane(PlaneCreateRequest PlaneRequest);
        Task<PlaneUpdateResponse> UpdatePlane(PlaneUpdateRequest PlaneRequest);
        Task<bool> DeletePlane(int id);


    }
}
