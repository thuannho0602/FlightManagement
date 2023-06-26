using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Entity
{
    [Table("HoldtheSeat")]// Giữ ghế
    public class HoldTheSeat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CodePlace { get; set; }
        public int BookAPlaceId { get; set; }
       
        
    }
}
