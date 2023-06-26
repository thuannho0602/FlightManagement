using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.BookAPlace;
using FlightManagement.Model.Client;
using FlightManagement.Model.HoldSeat;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class BookAPlaceServices : IBookAPlaceServices
    {
        public readonly IHoldTheSeatRepository _holdTheSeatRepository;
        public readonly IClientRepository _clientRepository;
        public readonly IBookAPlaceRepository _bookAPlaceRepository;
        public ApplicationDbContext _appDbContext;
        public BookAPlaceServices(IHoldTheSeatRepository holdTheSeatRepository, IClientRepository clientRepository, IBookAPlaceRepository bookAPlaceRepository, ApplicationDbContext appDbContext)
        {
            _holdTheSeatRepository = holdTheSeatRepository;
            _clientRepository = clientRepository;
            _bookAPlaceRepository = bookAPlaceRepository;
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateBookAPlace(BookAPlaceCreateRequest bookAPlace)
        {
            if(bookAPlace != null)
            {
                var bookAPlaceDb = new BookAPlace
                {
                    StartDate = bookAPlace.StartDate,
                    ReturnDay = bookAPlace.ReturnDay,
                    ClientID = bookAPlace.ClientID,
                    FlightID = bookAPlace.FlightID,
                };
                _bookAPlaceRepository.Add(bookAPlaceDb);
                _bookAPlaceRepository.SaveChanges();
                return await Task.FromResult(bookAPlaceDb.ID);
            }
            return -1;
        }

        public async Task<bool> CreateBookAPlace(BookAPlaceInof bookAPlaceInof)
        {
            if(bookAPlaceInof.Client != null)
            {
                var client = new Client
                {
                    FullName = bookAPlaceInof.Client.FullName,
                    PhoneNumber = bookAPlaceInof.Client.PhoneNumber,
                    Email = bookAPlaceInof.Client.Email,
                    DateOfBirth = bookAPlaceInof.Client.DateOfBirth,
                    Sex = bookAPlaceInof.Client.Sex,
                };
                _clientRepository.Add(client);
                _clientRepository.SaveChanges();
                var bookAPlace = new BookAPlace
                {
                    StartDate = bookAPlaceInof.BookAPlace.StartDate,
                    ReturnDay = bookAPlaceInof.BookAPlace.ReturnDay,
                    FlightID = bookAPlaceInof.BookAPlace.FlightID,
                    ClientID = bookAPlaceInof.BookAPlace.ClientID,

                };
                _bookAPlaceRepository.Add(bookAPlace);
                _bookAPlaceRepository.SaveChanges();

                if (bookAPlaceInof.HoldSeats.Any())
                {
                    foreach(var item in bookAPlaceInof.HoldSeats)
                    {
                        var holdSeat = new HoldTheSeat
                        {
                            BookAPlaceId = bookAPlace.ID,
                            CodePlace = item.CodePlace,
                        };
                        _holdTheSeatRepository.Add(holdSeat);
                    }
                    _holdTheSeatRepository.SaveChanges();
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<int> CreateClient(ClientCreateRequest client)
        {
            if(client != null)
            {
                var clientDb = new Client
                {
                    FullName = client.FullName,
                    PhoneNumber = client.PhoneNumber,
                    Email = client.Email,
                    DateOfBirth = client.DateOfBirth,
                    Sex = client.Sex,
                };
                _clientRepository.Add(clientDb);
                _clientRepository.SaveChanges();
                return await Task.FromResult(clientDb.Id);
            }
            return -1;
        }

        public async Task<bool> CreateHoldtheSeat(int bookAPlaceID, HoldSeatInfo holdSeat)
        {
            var listholdSeat = holdSeat.CodePlace.Split(",");
            if (listholdSeat.Any()) ;
            {
                foreach (var item in listholdSeat)
                {
                    var holdSeatInfo = new HoldTheSeat
                    {
                        BookAPlaceId = bookAPlaceID,
                        CodePlace = item,
                    };
                    _holdTheSeatRepository.Add(holdSeatInfo);
                }
                _holdTheSeatRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return false;
        }

        

        public async Task<List<CustomerInformationBookingTickets>> GetCustomerInformation()
        {
            var list = (from bookAPlace in _bookAPlaceRepository.FindAll()
                        join flight in _appDbContext.Flights on bookAPlace.FlightID equals flight.Id
                        join plane in _appDbContext.Planes on flight.PlaneID equals plane.Id
                        join client in _clientRepository.FindAll() on bookAPlace.ClientID equals client.Id
                        select new CustomerInformationBookingTickets
                        {
                            FullName = client.FullName,
                            PhoneNumber = client.PhoneNumber,
                            Email = client.Email,
                            Time = flight.DepartureTime.ToString("hh\\:mm"),
                            StartDate = bookAPlace.StartDate.ToString(@"dd/MM/yyyy"),
                            ReturnDay = bookAPlace.ReturnDay.HasValue ? bookAPlace.ReturnDay.Value.ToString(@"dd/MM/yyyy") : null,
                            NamePlane = plane.NamePlane,

                        }).ToList();
            return await Task.FromResult(list);
        }

        public async Task<List<HoldSeatResponse>> GetHoldTheSeatSeatSeat(HoldSeatRequest holdSeatRequest)
        {
            try
            {
                var listholdSeat = (from bookAPlace in _bookAPlaceRepository.FindByCondition(c => c.StartDate == holdSeatRequest.StartDate.Date &&
                                  (c.ReturnDay == null || (c.ReturnDay == null ? c.ReturnDay == null : c.ReturnDay.Value.Date == (holdSeatRequest.ReturnDay == null ?
                                  holdSeatRequest.ReturnDay : holdSeatRequest.ReturnDay.Value.Date))) && c.FlightID == holdSeatRequest.FlightID)
                                    join client in _clientRepository.FindAll() on bookAPlace.ClientID equals client.Id
                                    join holdSeat in _holdTheSeatRepository.FindAll() on bookAPlace.ID equals holdSeat.Id
                                    select new HoldSeatResponse
                                    {
                                        BookAPlaceId = bookAPlace.ID,
                                        Id = holdSeat.Id,
                                        SeatCode = holdSeat.CodePlace.Trim()
                                    }).ToList();
                return await Task.FromResult(listholdSeat);
            }
            catch(Exception ex)
            {
                return new List<HoldSeatResponse>();
            }
        }

        public async Task<List<RevenueByMonthResponse>> GetMonthlyRevenueReport(int month)
        {
            var list = (from bookAPlace in _bookAPlaceRepository.FindAll()
                        join flight in _appDbContext.Flights on bookAPlace.FlightID equals flight.Id
                        join plane in _appDbContext.Planes on flight.PlaneID equals plane.Id
                        select new
                        {
                            BookAPlaceId = bookAPlace.ID,
                            Month = bookAPlace.StartDate.Month,
                            FlightID = flight.Id,
                            PlaneId = flight.Id,
                            Revenue = flight.Price,
                            NamePlane = plane.NamePlane,

                        }).ToList();
            list =list.Where(c=>c.Month==month).ToList();
            var listGoup = list.GroupBy(c => new { c.NamePlane, c.FlightID, c.PlaneId }).Select(c => new RevenueByMonthResponse
            {
                NamePlane = c.Key.NamePlane,
                PlaneId = c.Key.PlaneId,
                FlightId = c.Key.FlightID,
                Revenue = c.Sum(x => x.Revenue),
                TicketNumber = c.Count(),
            }).ToList();
            return await Task.FromResult(listGoup);
        }
        public async Task<List<RevenueByYearResponse>> GetAnnualRevenueReport(int year)
        {
            var list = (from bookAPlace in _bookAPlaceRepository.FindAll()
                        join flight in _appDbContext.Flights on bookAPlace.FlightID equals flight.Id
                        join plane in _appDbContext.Planes on flight.PlaneID equals plane.Id
                        select new
                        {
                            BookAPlaceId = bookAPlace.ID,
                            Month = bookAPlace.StartDate.Month,
                            Year = bookAPlace.StartDate.Year,
                            FlightId = flight.Id,
                            PlaneId = plane.Id,
                            Revenue = flight.Price,
                            NamePlane = plane.NamePlane,
                        }).ToList();
            list= list.Where(c=>c.Year==year ).ToList();
            var listGoup = list.GroupBy(c => new { c.Month, c.NamePlane, c.PlaneId }).Select(c => new RevenueByYearResponse
            {
                Month = c.Key.Month,
                NamePlane = c.Key.NamePlane,
                PlaneId = c.Key.PlaneId,
                Revenue = c.Sum(x => x.Revenue),
                FlightNumber = c.Count(),
            }).ToList();
            return await Task.FromResult(listGoup);
        }
    }
}
