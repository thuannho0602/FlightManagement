using FlightManagement.DataAccess;
using FlightManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Repository.Implementations
{
    public class ArrivalAirportRepository:RepositoryBase<ArrivalAirport, ApplicationDbContext>, IArrivalAirportRepository
    {
        public ArrivalAirportRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
