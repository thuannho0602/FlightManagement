using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.Flight
{
    public class FlightByAirportRequest
    {
        public int AirportDepartureID { get; set; }
        public int ArrivalAirportID { get; set; }
    }
}
