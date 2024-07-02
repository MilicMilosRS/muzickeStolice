using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Ocena
    {
        private IOcenljivo primalac;
        public IOcenljivo Primalac
        {
            get { return primalac; }
        }

        private Korisnik autor;
        public Korisnik Autor
        {
            get { return autor; }
        }

        private int vrednost;

        public Ocena(IOcenljivo primalac, Korisnik autor, int vrednost)
        {
            this.primalac = primalac;
            this.autor = autor;
            this.vrednost = vrednost;
        }

        public int Vrednost
        {
            get { return vrednost; }
            set { vrednost = value; }
        }
    }
}
