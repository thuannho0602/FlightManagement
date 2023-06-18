using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Entity
{
    [Table("AirportDeparture")]//Sân bay khởi hành
    public class AirportDeparture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameAirportDeparture { get; set; }
    }
}
