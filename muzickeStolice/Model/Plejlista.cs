using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Plejlista
    {
        private Korisnik autor;
        public Korisnik Autor
        {
            get { return autor; }
        }

        private List<MuzickoDelo> muzika;
        public List<MuzickoDelo> Muzika
        {
            get { return muzika; }
        }

        private Zanr zanr;

        public Plejlista(Korisnik autor, Zanr zanr)
        {
            this.autor = autor;
            this.muzika = new List<MuzickoDelo>();
            this.zanr = zanr;
        }

        public Zanr Zanr
        {
            get { return zanr; }
            set { zanr = value; }
        }
    }
}
