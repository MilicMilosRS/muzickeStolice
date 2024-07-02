using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using muzickeStolice.Model;

namespace muzickeStolice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=muzickeStoliceDb; Username=postgres; Password=admin");
        }

        public DbSet<Bend> Bendovi { get; set; }
        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<MuzickoDelo> MuzickaDela { get; set; }
    }
}
