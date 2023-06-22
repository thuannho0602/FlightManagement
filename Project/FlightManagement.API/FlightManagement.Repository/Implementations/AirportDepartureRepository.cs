using FlightManagement.DataAccess;
using FlightManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Repository.Implementations
{
    public class AirportDepartureRepository:RepositoryBase<AirportDeparture,ApplicationDbContext>, IAirportDepartureRepository
    {
        public AirportDepartureRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
