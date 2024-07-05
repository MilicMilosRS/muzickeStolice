using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Profil
    {
        public Profil() { }

        private Korisnik korisnik;
        [Key]
        public string korisnikEmail
        {
            get { return korisnik.Email; }
            set { }
        }
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
        public bool PrikaziOcene
        {
            get { return prikaziOcene; }
            set { prikaziOcene = value; }
        }

        public List<String> slikeLinkovi { get; set; }

        public Profil(Korisnik korisnik, string ime, string prezime)
        {
            this.korisnik = korisnik;
            this.ime = ime;
            this.prezime = prezime;
            this.prikaziRecenzije = false;
            this.prikaziOcene = false;
            slikeLinkovi = new List<string>();
        }



    }
}
