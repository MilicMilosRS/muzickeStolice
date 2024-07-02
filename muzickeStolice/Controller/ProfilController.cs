using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class ProfilController
    {
        static private List<Profil> _data = new List<Profil>();
        
        static public Profil? Read(string korisnikEmail)
        {
            foreach (Profil p in _data)
                if (p.Korisnik.Email == korisnikEmail)
                    return p;
            return null;
        }

        static public Profil Create(string korisnikEmail, string ime, string prezime)
        {
            Korisnik? k = KorisnikController.Read(korisnikEmail);
            if (k == null)
                throw new ArgumentException("Ne postoji korisnik sa tim mejlom");
            if (Read(korisnikEmail) != null)
                throw new ArgumentException("Taj korisnik vec ima profil");
            Profil p = new Profil(k, ime, prezime);
            _data.Add(p);
            return p;
        }

        static public void Update(string korisnikEmail, string ime, string prezime)
        {
            Profil? p = Read(korisnikEmail);
            if (p == null)
                return;
            p.Ime = ime;
            p.Prezime = prezime;
        }

        static public void Delete(string korisnikEmail)
        {
            Profil? p = Read(korisnikEmail);
            if (p == null)
                return;
            _data.Remove(p);
        }
    }
}
