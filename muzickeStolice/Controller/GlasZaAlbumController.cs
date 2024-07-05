using Microsoft.EntityFrameworkCore;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class GlasZaAlbumController
    {
        public static GlasZaAlbum? Read(Korisnik k, int god)
        {
            GlasZaAlbum? album = DatabaseController.database.Glasovi.Include(g => g.Album).FirstOrDefault(g => g.Korisnik == k && g.Godina == god);
            return album;
        }

        public static GlasZaAlbum CreateOrUpdate(Korisnik k, MuzickoDelo a, int god)
        {
            GlasZaAlbum? g = Read(k, god);

            if (g == null)
            {
                g = new GlasZaAlbum(k, a, god);
                DatabaseController.database.Glasovi.Add(g);
            }
            else
                g.Album = a;
            DatabaseController.database.SaveChanges();
            return g;
        }

        public static void Delete(Korisnik k, int god)
        {
            GlasZaAlbum? g = Read(k, god);
            if (g == null)
                return;
            DatabaseController.database.Glasovi.Remove(g);
        }
    }
}
