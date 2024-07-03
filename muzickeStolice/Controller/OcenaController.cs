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

        static public List<Ocena> getOcenaForKorisnik(string email)
        {
            List<Ocena> listaOcena = new List<Ocena>();
            for(int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Autor.Email == email)
                {
                    listaOcena.Add(_data[i]);
                }
            }
            return listaOcena;

        }

        static public void Update(string autorEmail, Ocenljivo primalac, int vrednost)
        {
            Ocena? o = Read(autorEmail, primalac);
            if (o == null)
                return;
            o.Vrednost = vrednost;
        }

        static public void AddOcena(Ocena o)
        {
            _data.Add(o);
        }

        static public void Delete(string autorEmail, Ocenljivo primalac)
        {
            Ocena? o = Read(autorEmail, primalac);
            if (o == null)
                return;
            _data.Remove(o);
        }
        static public Ocena? GetOcena(int primalacId, string autorEmail)
        {
            return _data.FirstOrDefault(o => o.Primalac.ID == primalacId && o.Autor.Email == autorEmail);
        }
        static public List<Ocena> GetOcenasForOcenljivo(int ocenljivoId)
        {
            return _data.Where(o => o.Primalac.ID == ocenljivoId).ToList();
        }
    }
}
