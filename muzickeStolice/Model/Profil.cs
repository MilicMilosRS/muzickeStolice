using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Profil
    {
        private Korisnik korisnik;
        public Korisnik Korisnik
        {
            get { return korisnik; }
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

        private bool prikaziRecenzije;
        public bool PrikaziRecenzije
        {
            get { return prikaziRecenzije; }
            set { prikaziRecenzije = value; }
        }

        private bool prikaziOcene;

        public Profil(Korisnik korisnik, string ime, string prezime)
        {
            this.korisnik = korisnik;
            this.ime = ime;
            this.prezime = prezime;
            this.prikaziRecenzije = false;
            this.prikaziOcene = false;
        }

        public bool PrikaziOcene
        {
            get { return prikaziOcene; }
            set { prikaziOcene = value; }
        }


    }
}
