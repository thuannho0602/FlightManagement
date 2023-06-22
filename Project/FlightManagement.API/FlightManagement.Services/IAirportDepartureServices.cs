using FlightManagement.Model.AirportDeparture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services
{
    public interface IAirportDepartureServices
    {
        Task<List<AirportDepartureGetReponse>> GetAll();
        Task<AirportDepartureGetReponse> GetById(int id);
        Task<AirportDepartureCreateResponse> CreateAirportDeparture(AirportDepartureCreateRequest airportDepartureCreateRequest);
        Task<AirportDepartureUpdateResponse> UpdateAirportDeparture(int Id, AirportDepartureUpdateRequest airportDepartureUpdateRequest);
        Task<bool> DeleteAirportDeparture(int Id);
    }
}
