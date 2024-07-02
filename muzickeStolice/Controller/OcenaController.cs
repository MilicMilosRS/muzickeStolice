using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class OcenaController
    {
        static private List<Ocena> _data = new List<Ocena>();

        static public Ocena? Read(string autorEmail, Ocenljivo primalac)
        {
            foreach (Ocena o in _data)
                if (o.Autor.Email == autorEmail && o.Primalac == primalac)
                    return o;
            return null;
        }

        static public Ocena Create(string autorEmail, Ocenljivo primalac, int vrednost)
        {
            Korisnik? k = KorisnikController.Read(autorEmail);
            if (k == null)
                throw new ArgumentException("Ne postoji korisnik sa tim mejlom");
            Ocena o = new Ocena(primalac, k, vrednost);
            _data.Add(o);
            return o;
        }

        static public void Update(string autorEmail, Ocenljivo primalac, int vrednost)
        {
            Ocena? o = Read(autorEmail, primalac);
            if (o == null)
                return;
            o.Vrednost = vrednost;
        }

        static public void Delete(string autorEmail, Ocenljivo primalac)
        {
            Ocena? o = Read(autorEmail, primalac);
            if (o == null)
                return;
            _data.Remove(o);
        }
    }
}
