using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class KorisnikController
    {
        static private List<Korisnik> _data = new List<Korisnik>();

        static public Korisnik? Read(string email)
        {
            foreach (Korisnik k in _data)
                if (k.Email == email)
                    return k;
            return null;
        }

        static public Korisnik? ReadKorIme(string korisnickoIme)
        {
            foreach (Korisnik k in _data)
                if (k.KorisnickoIme == korisnickoIme)
                    return k;
            return null;
        }



        static public Korisnik Create(string email, string korisnickoIme, string lozinka, TipKorisnika tip)
        {
            if (Read(email) != null)
                throw new ArgumentException("EMail je vec zauzet");
            if (ReadKorIme(korisnickoIme) != null)
                throw new ArgumentException("Korisnicko ime je vec zauzeto");
            Korisnik k = new Korisnik(email, korisnickoIme, lozinka, tip);
            _data.Add(k);
            return k;
        }

        static public void Update(string email, Korisnik k2)
        {
            Korisnik? k = Read(email);
            if (k == null)
                return;
            k.Lozinka = k2.Lozinka;
            k.Tip = k2.Tip;
        }

        static public void Delete(string email)
        {
            Korisnik? k = Read(email);
            if (k == null)
                return;
            _data.Remove(k);
        }
    }
}
