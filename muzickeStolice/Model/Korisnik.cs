using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{

    public class Korisnik
    {
        public Korisnik() { }

        private string email;
        [Key]
        public string Email
        {
            get { return email; }
            set { }
        }

        private string korisnickoIme;
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
        }

        private string lozinka;
        public string Lozinka
        {
            get { return lozinka; }
            set { lozinka = value; }
        }

        private TipKorisnika tip;

        public Korisnik(string email, string korisnickoIme, string lozinka, TipKorisnika tip)
        {
            this.email = email;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.tip = tip;
        }

        public TipKorisnika Tip
        {
            get { return tip; }
            set { tip = value; }
        }
    }
}
