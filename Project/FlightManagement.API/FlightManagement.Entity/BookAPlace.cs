using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Entity
{
    [Table("BookAPlace")]//Đặt chỗ
    public class BookAPlace
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDay { get; set; }
        public int FlightID { get; set; }
        public int ClientID { get; set; }
      
        



    }
}
