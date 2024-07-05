using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    [PrimaryKey(nameof(KorisnikEmail),nameof(AlbumId),nameof(Godina))]
    public class GlasZaAlbum
    {
        public string KorisnikEmail{ get; set; }
        public Korisnik Korisnik { get; set; }
        public int AlbumId { get; set; }
        public MuzickoDelo Album { get; set; }
        public int Godina { get; set; }

        public GlasZaAlbum() { }

        public GlasZaAlbum(Korisnik k, MuzickoDelo a, int god)
        {
            Korisnik = k;
            KorisnikEmail = k.Email;
            Album = a;
            AlbumId = a.Id;
            Godina = god;
        }
    }
}
