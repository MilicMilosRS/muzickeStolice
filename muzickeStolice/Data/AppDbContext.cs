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
        public DbSet<Izdanje> Izdanja { get; set; }
        public DbSet<IzdanjeIzvodjenja> IzdanjaIzvodjenja{ get; set; }
        public DbSet<Izvodjac> Izvodjaci { get; set; }
        public DbSet<Izvodjenje> Izvodjenja { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<MuzickoDelo> MuzickaDela { get; set; }
        public DbSet<Ocena> Ocene { get; set; }
        public DbSet<Ocenljivo> Ocenljivosti { get; set; }
        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Plejlista> Plejliste { get; set; }
        public DbSet<Profil> Profili { get; set; }
        public DbSet<Recenzija> Recenzije { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<GlasZaAlbum> Glasovi { get; set; }

    }
}
