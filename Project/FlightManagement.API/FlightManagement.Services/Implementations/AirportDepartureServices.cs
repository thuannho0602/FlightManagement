using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.AirportDeparture;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class AirportDepartureServices : IAirportDepartureServices
    {
        private readonly IAirportDepartureRepository _airportDepartureRepository;
        private readonly ApplicationDbContext _appDbContext;
        public AirportDepartureServices(IAirportDepartureRepository airportDepartureRepository, ApplicationDbContext appDbContext)
        {
            _airportDepartureRepository = airportDepartureRepository;
            _appDbContext = appDbContext;
        }

        public async Task<AirportDepartureCreateResponse> CreateAirportDeparture(AirportDepartureCreateRequest airportDepartureCreateRequest)
        {
            if(airportDepartureCreateRequest.Id == 0)
            {
                var airportDeparture = new AirportDeparture
                {
                    Code = airportDepartureCreateRequest.Code,
                    NameAirportDeparture = airportDepartureCreateRequest.NameAirportDeparture
                };
                _airportDepartureRepository.Add(airportDeparture);
                _airportDepartureRepository.SaveChanges();
                var airportDepartureResponse = new AirportDepartureCreateResponse
                {
                    Id= airportDeparture.Id,
                    Code= airportDeparture.Code,   
                    NameAirportDeparture=airportDeparture.NameAirportDeparture,
                };
                return await Task.FromResult(airportDepartureResponse);
            }
            else
            {
                return new AirportDepartureCreateResponse();
            }
            
        }

        public async Task<bool> DeleteAirportDeparture(int Id)
        {
            var airportDeparture = _airportDepartureRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if (airportDeparture != null)
            {
                _airportDepartureRepository.Delete(airportDeparture);
                _airportDepartureRepository.SaveChanges();
            }
            return await Task.FromResult(false);

        }

        public async Task<List<AirportDepartureGetReponse>> GetAll()
        {
            var listairportDeparture = _airportDepartureRepository.FindAll().Select(c => new AirportDepartureGetReponse
            {
                Id = c.Id,
                Code = c.Code,
                NameAirportDeparture=c.NameAirportDeparture,
            }).ToList();
            return await Task.FromResult(listairportDeparture);
        }

        public async Task<AirportDepartureGetReponse> GetById(int id)
        {
            var airportDeparture = _airportDepartureRepository.FindByCondition(c => c.Id == id).Select(c => new AirportDepartureGetReponse
            {
                Id=c.Id,
                Code=c.Code,
                NameAirportDeparture=c.NameAirportDeparture,
            }).FirstOrDefault();
            return await Task.FromResult(airportDeparture);
        }

        public async Task<AirportDepartureUpdateResponse> UpdateAirportDeparture(int Id, AirportDepartureUpdateRequest airportDepartureUpdateRequest)
        {
            if (Id > 0)
            {
                var airportDeparture = _airportDepartureRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
                if(airportDeparture != null)
                {
                    var airportDepartureMode = new AirportDeparture
                    {
                        Id = Id,
                        Code = airportDepartureUpdateRequest.Code,
                        NameAirportDeparture = airportDepartureUpdateRequest.NameAirportDeparture,
                    };
                    _airportDepartureRepository.Update(airportDepartureMode);
                    _airportDepartureRepository.SaveChanges();
                    var airportDepartureResponse = new AirportDepartureUpdateResponse
                    {
                        Id = airportDepartureMode.Id,
                        Code = airportDepartureMode.Code,
                        NameAirportDeparture = airportDepartureMode.NameAirportDeparture,
                    };
                    return await Task.FromResult(airportDepartureResponse);
                }
                else
                {
                    return new AirportDepartureUpdateResponse();
                }
            }
            else
            {
                return new AirportDepartureUpdateResponse();
            }
        }
    }
}
