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
        static public List<Plejlista> getKorisnikPlejliste(string autorEmail)
        {
            Korisnik? autor = KorisnikController.Read(autorEmail);
            if (autor == null)
                throw new ArgumentException("Ne postoji korisnik sa tim mejlom");

            List<Plejlista> korisnikovePlejliste = _data.Where(p => p.Autor.Email == autorEmail).ToList();
            return korisnikovePlejliste;
        }

        static public void AddToPlaylist(int playlistID, int muzickoDelo)
        {
            Plejlista p = Read(playlistID);
            MuzickoDelo md = MuzickoDeloController.Read(muzickoDelo);
            p.Muzika.Add(md);
        }

        static public void RatePlaylist(int playlistId, int vrednost, string autorEmail)
        {
            Plejlista? playlist = Read(playlistId);
            if (playlist == null)
                throw new ArgumentException("Plejlista nije pronadjena");

            Ocena? ocena = OcenaController.GetOcena(playlist.ID, autorEmail);
            if (ocena != null)
            {
                ocena.Vrednost = vrednost;
            }
            else
            {
                OcenaController.Create(autorEmail, new Ocenljivo { ID = playlist.ID }, vrednost);
            }
        }

        static public List<Plejlista> GetSortedPlaylistsByRating()
        {
            List<Plejlista> playlistsWithRatings = new List<Plejlista>();

            foreach (var playlist in _data)
            {
                var ocene = OcenaController.GetOcenasForOcenljivo(playlist.ID);
                if (ocene.Count > 0)
                {
                    playlistsWithRatings.Add(playlist);
                }
            }

            playlistsWithRatings.Sort((x, y) =>
            {
                double avgX = OcenaController.GetOcenasForOcenljivo(x.ID).Average(o => o.Vrednost);
                double avgY = OcenaController.GetOcenasForOcenljivo(y.ID).Average(o => o.Vrednost);
                return avgY.CompareTo(avgX);
            });

            return playlistsWithRatings;
        }

    }
}
