using Microsoft.EntityFrameworkCore;
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
        static private int GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (Plejlista b in DatabaseController.database.Plejliste)
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
            foreach (Plejlista p in DatabaseController.database.Plejliste)
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
            DatabaseController.database.Plejliste.Add(p);
            DatabaseController.database.SaveChanges();
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

            DatabaseController.database.SaveChanges();
        }

        static public void Delete(int id)
        {
            Plejlista? p = Read(id);
            if (p == null)
                return;
            DatabaseController.database.Plejliste.Remove(p);
            DatabaseController.database.SaveChanges();
        }
        static public List<Plejlista> getKorisnikPlejliste(string autorEmail)
        {
            Korisnik? autor = KorisnikController.Read(autorEmail);
            if (autor == null)
                throw new ArgumentException("Ne postoji korisnik sa tim mejlom");

            List<Plejlista> korisnikovePlejliste = DatabaseController.database.Plejliste.Include(p => p.Autor)
                .Where(p => p.Autor.Email == autorEmail).ToList();
            return korisnikovePlejliste;
        }

        static public void AddToPlaylist(int playlistID, int muzickoDelo)
        {
            Plejlista p = Read(playlistID);
            MuzickoDelo md = MuzickoDeloController.Read(muzickoDelo);
            p.Muzika.Add(md);
            DatabaseController.database.SaveChanges();
        }

    }
}
