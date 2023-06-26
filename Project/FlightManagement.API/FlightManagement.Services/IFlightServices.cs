using FlightManagement.Model.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services
{
    public interface IFlightServices
    {
        Task<List<FlightGetRespone>> GetAll();
        Task<FlightGetRespone> GetById(int id);
        Task<FlightCreateRespone> CreateFlight(FlightCreateRequest flightCreateRequest );
        Task<FlightUpdateResponse> UpdateFlight(int Id, FlightUpdateRequest flightUpdateRequest);
        Task<bool>DeleteFlight(int Id);
        Task<List<FlightGetRespone>> GetFlightByAirport(FlightByAirportRequest flightByAirportRequest);
    }
}
