using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.HoldSeat
{
    public class HoldSeatRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDay { get; set; }
        public int FlightID { get; set; }
        
    }
    public class HoldSeatInfo
    {
        public string CodePlace { get; set; }
    }
}
