using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Bend
    {
        public Bend() { }

        public int Id { get; set; }
        public Izvodjac Izvodjac{get;set;}

        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private string opis;
        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public IList<string> slikeLinkovi { get; set; }

        private DateOnly datumOsnivanja;

        public ICollection<Osoba> clanovi { get; set; }

        public Bend(Izvodjac iz, string naziv, string opis, DateOnly datumOsnivanja)
        {
            Izvodjac = iz;
            Id = Izvodjac.ID;
            this.naziv = naziv;
            this.opis = opis;
            this.datumOsnivanja = datumOsnivanja;
            clanovi = new List<Osoba>();
        }

        public DateOnly DatumOsnivanja
        {
            get { return datumOsnivanja; }
            set { datumOsnivanja = value; }
        }
    
        public void View(IIzvodjacVisitor visitor)
        {
            visitor.ViewBend(this);
        }
    }
}
