using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class PlejlistaController
    {
        static private List<Plejlista> _data = new List<Plejlista>();

        static private int GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (Plejlista b in _data)
                    if (b.ID == i)
                    {
                        taken = true;
                        break;
                    }
                if (!taken)
                    return i;
            }
        }

        static public Plejlista? Read(int id)
        {
            foreach (Plejlista p in _data)
                if (p.ID == id)
                    return p;
            return null;
        }

        static public Plejlista Create(string autorEmail, string zanrNaziv)
        {
            Korisnik? autor = KorisnikController.Read(autorEmail);
            if (autor == null)
                throw new ArgumentException("Ne postoji korisnik sa tim mejlom");
            Zanr? z = ZanrController.Read(zanrNaziv);
            if (z == null)
                throw new ArgumentException("Ne postoji zanr sa tim nazivom");

            Plejlista p = new Plejlista(autor, z);
            _data.Add(p);
            return p;
        }

        static public void Update(int id, string zanrNaziv)
        {
            Plejlista? p = Read(id);
            if (p == null)
                return;

            Zanr? z = ZanrController.Read(zanrNaziv);
            if (z == null)
                return;

            p.Zanr = z;
        }

        static public void Delete(int id)
        {
            Plejlista? p = Read(id);
            if (p == null)
                return;
            _data.Remove(p);
        }
    }
}
