using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.Flight;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class FlightServices : IFlightServices
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ApplicationDbContext _appDbContext;
        public FlightServices(IFlightRepository flightRepository, ApplicationDbContext appDbContext)
        {
            _flightRepository = flightRepository;
            _appDbContext = appDbContext;
        }

        public async Task<FlightCreateRespone> CreateFlight(FlightCreateRequest flightCreateRequest)
        {
            if(flightCreateRequest.Id == 0)
            {
                var flight=new Flight
                {
                    DepartureTime=TimeSpan.Parse(flightCreateRequest.DepartureTime),
                    Price= flightCreateRequest.Price,
                    Time= flightCreateRequest.Time,
                    PlaneID= flightCreateRequest.PlaneID,
                    AirportDepartureID= flightCreateRequest.AirportDepartureID,
                    ArrivalAirportID= flightCreateRequest.ArrivalAirportID,

                };
                _flightRepository.Add(flight);
                _flightRepository.SaveChanges();

                var flightRespone = new FlightCreateRespone
                {
                    Id = flight.Id,
                    DepartureTime = flight.DepartureTime.ToString("hh\\:mm"),
                    Price = flight.Price,
                    Time = flight.Time,
                    PlaneID = flight.PlaneID,
                    NamePlane = _appDbContext.Planes.Where(x => x.Id == flight.PlaneID).FirstOrDefault().NamePlane,
                    ArrivalAirportID = flight.ArrivalAirportID,
                    NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == flight.PlaneID).FirstOrDefault().NameArrivalAirport,
                    AirportDepartureID = flight.AirportDepartureID,
                    NameAirportDeparture = _appDbContext.ArrivalAirports.Where(x => x.Id == flight.AirportDepartureID).FirstOrDefault().NameArrivalAirport,
                };
                return await Task.FromResult(flightRespone);
            }
            else
            {
                return new FlightCreateRespone();
            }
        }

        public async Task<bool> DeleteFlight(int Id)
        {
           var flight=_flightRepository.FindByCondition(c=>c.Id== Id).FirstOrDefault();
            if (flight != null)
            {
                _flightRepository.Remove(flight);
                _flightRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return true;
        }

        public async Task<List<FlightGetRespone>> GetAll()
        {
            var listflight = _flightRepository.FindAll().Select(c => new FlightGetRespone
            {
                Id = c.Id,
                Price = c.Price,
                DepartureTime = c.DepartureTime.ToString("hh\\:mm"),
                Time = c.Time,
                PlaneID = c.PlaneID,
                NamePlane = _appDbContext.Planes.Where(x => x.Id == c.PlaneID).FirstOrDefault().NamePlane,
                ArrivalAirportID = c.ArrivalAirportID,
                NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == c.PlaneID).FirstOrDefault().NameArrivalAirport,
                AirportDepartureID = c.AirportDepartureID,
                NameAirportDeparture = _appDbContext.ArrivalAirports.Where(x => x.Id == c.AirportDepartureID).FirstOrDefault().NameArrivalAirport,
            }).ToList();
            return await Task.FromResult(listflight);
        }

        public async Task<FlightGetRespone> GetById(int id)
        {
            var flight=_flightRepository.FindByCondition(c=>c.Id== id).Select(c=>new FlightGetRespone
            {
                Id = c.Id,
                Price = c.Price,
                DepartureTime = c.DepartureTime.ToString("hh\\:mm"),
                Time = c.Time,
                PlaneID = c.PlaneID,
                NamePlane = _appDbContext.Planes.Where(x => x.Id == c.PlaneID).FirstOrDefault().NamePlane,
                ArrivalAirportID = c.ArrivalAirportID,
                NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == c.PlaneID).FirstOrDefault().NameArrivalAirport,
                AirportDepartureID = c.AirportDepartureID,
                NameAirportDeparture = _appDbContext.ArrivalAirports.Where(x => x.Id == c.AirportDepartureID).FirstOrDefault().NameArrivalAirport,
            }).FirstOrDefault();
            return await Task.FromResult(flight);
        }

        public async Task<List<FlightGetRespone>> GetFlightByAirport(FlightByAirportRequest flightByAirportRequest)
        {
            var listflight=_flightRepository.FindByCondition(c=>c.ArrivalAirportID==flightByAirportRequest.ArrivalAirportID 
            && c.AirportDepartureID==flightByAirportRequest.AirportDepartureID).Select(c=>new FlightGetRespone
            {
                Id = c.Id,
                Price = c.Price,
                DepartureTime = c.DepartureTime.ToString("hh\\:mm"),
                Time = c.Time,
                PlaneID = c.PlaneID,
                NamePlane = _appDbContext.Planes.Where(x => x.Id == c.PlaneID).FirstOrDefault().NamePlane,
                ArrivalAirportID = c.ArrivalAirportID,
                NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == c.PlaneID).FirstOrDefault().NameArrivalAirport,
                AirportDepartureID = c.AirportDepartureID,
                NameAirportDeparture = _appDbContext.ArrivalAirports.Where(x => x.Id == c.AirportDepartureID).FirstOrDefault().NameArrivalAirport,
            }).ToList();
            return await Task.FromResult(listflight);
        }

        public async Task<FlightUpdateResponse> UpdateFlight(int Id, FlightUpdateRequest flightUpdateRequest)
        {
            var flight = _flightRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if (flight != null)
            {
                flight = new Flight
                {
                    Id = Id,
                    DepartureTime = TimeSpan.Parse(flightUpdateRequest.DepartureTime),
                    Price = flightUpdateRequest.Price,
                    Time = flightUpdateRequest.Time,
                    PlaneID = flightUpdateRequest.PlaneID,
                    AirportDepartureID = flightUpdateRequest.AirportDepartureID,
                    ArrivalAirportID = flightUpdateRequest.AirportDepartureID,
                };
                _flightRepository.Update(flight);
                _flightRepository.SaveChanges();

                var flightResponse = new FlightUpdateResponse
                {
                    Id = flight.Id,
                    Price = flight.Price,
                    DepartureTime = flight.DepartureTime.ToString("hh\\:mm"),
                    Time = flight.Time,
                    PlaneID = flight.PlaneID,
                    NamePlane = _appDbContext.Planes.Where(x => x.Id == flight.PlaneID).FirstOrDefault().NamePlane,
                    ArrivalAirportID = flight.ArrivalAirportID,
                    NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == flight.PlaneID).FirstOrDefault().NameArrivalAirport,
                    AirportDepartureID = flight.AirportDepartureID,
                    NameAirportDeparture = _appDbContext.ArrivalAirports.Where(x => x.Id == flight.AirportDepartureID).FirstOrDefault().NameArrivalAirport,
                };

                return await Task.FromResult(flightResponse);
            }
            else
            {
                return new FlightUpdateResponse();
            }
           
        }
    }
}
