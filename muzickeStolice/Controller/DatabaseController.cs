using Microsoft.EntityFrameworkCore;
using muzickeStolice.Data;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class DatabaseController
    {
        public static AppDbContext database = new AppDbContext();
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<MuzickoDelo> MuzickaDela { get; set; }
        public DbSet<Izvodjac> Izvodjaci { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
    }
}
