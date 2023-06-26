using FlightManagement.DataAccess;
using FlightManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Repository.Implementations
{
    public class FlightRepository : RepositoryBase<Flight, ApplicationDbContext>, IFlightRepository 
    {
        public FlightRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
