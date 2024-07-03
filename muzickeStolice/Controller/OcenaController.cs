using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        static public Ocena? Read(string autorEmail, Ocenljivo primalac)
        {
            foreach (Ocena o in DatabaseController.database.Ocene.Include(o => o.Primalac).Include(o => o.Autor))
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
            DatabaseController.database.Ocene.Add(o);
            DatabaseController.database.SaveChanges();
            return o;
        }

        static public List<Ocena> getOcenaForKorisnik(string email)
        {
            List<Ocena> listaOcena = new List<Ocena>();
            foreach(Ocena o in DatabaseController.database.Ocene.Include(o => o.Autor))
            {
                if (o.Autor.Email == email)
                {
                    listaOcena.Add(o);
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
            DatabaseController.database.SaveChanges();
        }

        static public void AddOcena(Ocena o)
        {
            DatabaseController.database.Add(o);
        }

        static public void Delete(string autorEmail, Ocenljivo primalac)
        {
            Ocena? o = Read(autorEmail, primalac);
            if (o == null)
                return;

            Recenzija? r = RecenzijaController.Read(o);
            if (r != null)
                RecenzijaController.Delete(o);

            DatabaseController.database.Ocene.Remove(o);
            DatabaseController.database.SaveChanges();
        }
        static public Ocena? GetOcena(int primalacId, string autorEmail)
        {
            return DatabaseController.database.Ocene.Include(o => o.Autor).Include(o => o.Primalac)
                .FirstOrDefault(o => o.Primalac.ID == primalacId && o.Autor.Email == autorEmail);
        }
        static public List<Ocena> GetOcenasForOcenljivo(int ocenljivoId)
        {
            return DatabaseController.database.Ocene.Include(o => o.Primalac).Where(o => o.Primalac.ID == ocenljivoId).ToList();
        }
    }
}
