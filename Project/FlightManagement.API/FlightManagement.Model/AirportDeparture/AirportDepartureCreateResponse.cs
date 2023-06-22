using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.AirportDeparture
{
    public class AirportDepartureCreateResponse ////Sân bay khởi hành
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameAirportDeparture { get; set; }
    }
}
