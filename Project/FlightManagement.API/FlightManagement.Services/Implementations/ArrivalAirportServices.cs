using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.ArrivalAirport;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class ArrivalAirportServices : IArrivalAirportServices
    {
        private readonly IArrivalAirportRepository _arrivalAirportRepository;
        private readonly ApplicationDbContext _appDbContext;
        public ArrivalAirportServices(IArrivalAirportRepository arrivalAirportRepository, ApplicationDbContext appDbContext)
        {
            _arrivalAirportRepository = arrivalAirportRepository;
            _appDbContext = appDbContext;
        }

        public async Task<ArrivalAirportCreateResponse> CreateArrivalAirport(ArrivalAirportCreateRequest arrivalAirportCreateRequest)
        {
            if(arrivalAirportCreateRequest.Id == 0)
            {
                var arrivalAirport = new ArrivalAirport
                {
                    Code = arrivalAirportCreateRequest.Code,
                    NameArrivalAirport = arrivalAirportCreateRequest.NameArrivalAirport,
                };
                _arrivalAirportRepository.Add(arrivalAirport);
                _arrivalAirportRepository.SaveChanges();

                var arrivalAirportResponse = new ArrivalAirportCreateResponse
                {
                    Id = arrivalAirport.Id,
                    Code = arrivalAirport.Code,
                    NameArrivalAirport = arrivalAirport.NameArrivalAirport,
                };
                return await  Task.FromResult(arrivalAirportResponse);
            }
            else
            {
                return new ArrivalAirportCreateResponse();
            }
        }

        public async Task<bool> DeleteArrivalAirport(int Id)
        {
            var arrivalAirport = _arrivalAirportRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if(arrivalAirport != null)
            {
                _arrivalAirportRepository.Remove(arrivalAirport);
                _arrivalAirportRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<List<ArrivalAirportGetResponse>> GetAll()
        {
            var listarrivalAirport = _arrivalAirportRepository.FindAll().Select(c => new ArrivalAirportGetResponse
            {
                Id = c.Id,
                Code = c.Code,
                NameArrivalAirport = c.NameArrivalAirport,
            }).ToList();
            return await Task.FromResult(listarrivalAirport);
        }

        public async Task<ArrivalAirportGetResponse> GetById(int id)
        {
            var arrivalAirport = _arrivalAirportRepository.FindByCondition(c => c.Id == id).Select(c => new ArrivalAirportGetResponse
            {
                Id = c.Id,
                Code = c.Code,
                NameArrivalAirport = c.NameArrivalAirport,
            }).FirstOrDefault();
            return await Task.FromResult(arrivalAirport);
        }

        public async Task<ArrivalAirportUpdateResponse> UpdateArrivalAirport(int Id, ArrivalAirportUpdateRequest arrivalAirportUpdateRequest)
        {
            if (Id > 0)
            {
                var arrivalAirport = new ArrivalAirport
                {
                    Id = Id,
                    Code = arrivalAirportUpdateRequest.Code,
                    NameArrivalAirport = arrivalAirportUpdateRequest.NameArrivalAirport,
                };
                _arrivalAirportRepository.Update(arrivalAirport);
                _arrivalAirportRepository.SaveChanges();

                var arrivalAirportResponse = new ArrivalAirportUpdateResponse
                {
                    Id = arrivalAirport.Id,
                    Code = arrivalAirport.Code,
                    NameArrivalAirport = arrivalAirport.NameArrivalAirport,
                };
                return await Task.FromResult(arrivalAirportResponse);
            }
            else
            {
                return new ArrivalAirportUpdateResponse();
            }
        }
    }
}
