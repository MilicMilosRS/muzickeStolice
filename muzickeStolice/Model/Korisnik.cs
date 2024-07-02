using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Korisnik
    {
        private string email;
        public string Email
        {
            get { return email; }
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
        }
    }
}
