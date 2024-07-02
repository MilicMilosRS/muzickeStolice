using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Osoba : IIzvodjac, IOcenljivo
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

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

        public Osoba(int id, string ime, string prezime, string biografija, DateOnly datumRodjenja)
        {
            this.id = id;
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
