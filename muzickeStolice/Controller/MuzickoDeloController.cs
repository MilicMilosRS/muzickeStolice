using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class MuzickoDeloController
    {
        static private List<MuzickoDelo> _data = new List<MuzickoDelo>();

        static public MuzickoDelo? Read(int id)
        {
            foreach (MuzickoDelo md in _data)
                if (md.Ocenljivo.ID == id)
                    return md;
            return null;
        }

        static public MuzickoDelo Create(string naziv, Zanr zanr, string opis, TipDela tip)
        {
            MuzickoDelo md = new MuzickoDelo(OcenljivoController.GenerateID(), naziv, zanr, opis, tip);
            _data.Add(md);
            return md;
        }

        static public void Update(int id, MuzickoDelo md2)
        {
            MuzickoDelo? md = Read(id);
            if (md == null)
                return;
            md.Opis = md2.Opis;
            md.ZanrDela = md2.ZanrDela;
            md.Naziv = md2.Naziv;
            md.Tip = md2.Tip;
            md.Izvodjaci.Clear();
            md.Izvodjaci.AddRange(md2.Izvodjaci);
        }

        static public void Delete(int id)
        {
            MuzickoDelo? md = Read(id);
            if (md == null)
                return;
            _data.Remove(md);
        }

        static public void RateMuzickoDelo(int ocenljivoId, int vrednost, string autorEmail)
        {
            if (vrednost < 1 || vrednost > 5)
                throw new ArgumentOutOfRangeException(nameof(vrednost), "Vrednost mora biti između 1 i 5.");

            MuzickoDelo? md = Read(ocenljivoId);
            if (md == null)
                throw new ArgumentException("Ne postoji Muzicko Delo sa tim ID-om.");

            Korisnik? autor = KorisnikController.Read(autorEmail);
            if (autor == null)
                throw new ArgumentException("Ne postoji korisnik sa tim email-om.");

            Ocena? ocena = OcenaController.GetOcena(ocenljivoId, autorEmail);
            if (ocena == null)
            {
                ocena = new Ocena(md.Ocenljivo, autor, vrednost);
                OcenaController.AddOcena(ocena);
            }
        }
        static public List<MuzickoDelo> GetSortedAlbumsByRating()
        {
            var albums = _data.Where(md => md.Tip == TipDela.Album).ToList();

            Dictionary<MuzickoDelo, double> albumRatings = new Dictionary<MuzickoDelo, double>();

            foreach (var album in albums)
            {
                var ocenas = OcenaController.GetOcenasForOcenljivo(album.Ocenljivo.ID);
                if (ocenas.Count > 0)
                {
                    double averageRating = ocenas.Average(o => o.Vrednost);
                    albumRatings[album] = averageRating;
                }
                else
                {
                    albumRatings[album] = 0;
                }
            }

            var sortedAlbums = albumRatings.OrderByDescending(ar => ar.Value).Select(ar => ar.Key).ToList();

            return sortedAlbums;
        }

    }
}
