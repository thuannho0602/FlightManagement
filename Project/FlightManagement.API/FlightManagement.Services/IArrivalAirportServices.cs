using FlightManagement.Model.ArrivalAirport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services
{
    public interface IArrivalAirportServices
    {
        Task<List<ArrivalAirportGetResponse>> GetAll();
        Task<ArrivalAirportGetResponse> GetById(int id);
        Task<ArrivalAirportCreateResponse> CreateArrivalAirport(ArrivalAirportCreateRequest arrivalAirportCreateRequest);
        Task<ArrivalAirportUpdateResponse> UpdateArrivalAirport(int Id,ArrivalAirportUpdateRequest arrivalAirportUpdateRequest);
        Task<bool> DeleteArrivalAirport(int Id);
    }
}
