﻿using FlightManagement.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataAccess
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<AirportDeparture> Airports { get; set; }
        public virtual DbSet<ArrivalAirport> ArrivalAirports { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<BookAPlace> BookAPlaces { get; set; }
        public virtual DbSet<HoldTheSeat> HoldTheSeats { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
