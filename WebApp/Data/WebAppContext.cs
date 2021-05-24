using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConstructWedDb.Models;

namespace WebApp.Data
{
    public class WebAppContext : DbContext
    {
        public WebAppContext (DbContextOptions<WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ConstructWedDb.Models.Brigade> Brigade { get; set; }

        public DbSet<ConstructWedDb.Models.Customer> Customer { get; set; }

        public DbSet<ConstructWedDb.Models.Material> Material { get; set; }

        public DbSet<ConstructWedDb.Models.Order> Order { get; set; }

        public DbSet<ConstructWedDb.Models.Position> Position { get; set; }

        public DbSet<ConstructWedDb.Models.Staff> Staff { get; set; }

        public DbSet<ConstructWedDb.Models.TypeOfJob> TypeOfJob { get; set; }
    }
}
