﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Entity
{
    [Table("Flight")]//Chuyến Bay 
    public class Flight
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int Time { get; set; }
        public decimal Price { get; set; }
        //Khóa Ngoại
        public int AirportDepartureID { get; set; }
        public AirportDeparture AirportDeparture { get; set; }
        public int ArrivalAirportID { get; set; }
        public ArrivalAirport ArrivalAirport { get; set; }
        public int PlaneID { get; set; }
        public Plane Plane { get; set; }
      
    }
}
