using Super_Solar_System.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Solar_System.Database
{
    public class SunContext : DbContext, IDisposable
    {
        public SunContext() : base("name = SunConnection") { }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<Moon> Moons { get; set; }
        public DbSet<Habitant> Habitants { get; set; }
        public object Habitant { get; set; }
        public object Moon { get; set; }
    }
}
