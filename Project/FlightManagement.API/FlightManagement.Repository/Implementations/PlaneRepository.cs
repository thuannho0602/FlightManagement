using FlightManagement.DataAccess;
using FlightManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Repository.Implementations
{
    public class PlaneRepository:RepositoryBase<Plane,ApplicationDbContext>
    {
        public PlaneRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
