using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lisa.Example.WebApi.Models
{
    public class AlertContext : DbContext
    {
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reporter> Reporters { get; set; }
    }
}