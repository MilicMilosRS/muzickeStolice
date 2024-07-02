using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Osoba
    {
        public int ID
        {
            get { return Izvodjac.ID; }
            set {  Izvodjac.ID = value;}
        }
        public Izvodjac Izvodjac{get;set;}

        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        private string biografija;
        public string Biografija
        {
            get { return biografija; }
            set { biografija = value; }
        }
        private DateOnly datumRodjenja;

        public Osoba() { }

        public Osoba(Izvodjac iz, string ime, string prezime, string biografija, DateOnly datumRodjenja)
        {
            this.Izvodjac = iz;
            this.ime = ime;
            this.prezime = prezime;
            this.biografija = biografija;
            this.datumRodjenja = datumRodjenja;
        }

        public DateOnly DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }

        public void View(IIzvodjacVisitor visitor)
        {
            visitor.ViewOsoba(this);
        }
    }
}
