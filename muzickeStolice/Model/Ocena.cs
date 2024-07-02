using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    [PrimaryKey(nameof(primalacId),nameof(autorEmail))]
    public class Ocena
    {
        public Ocena() { }

        private Ocenljivo primalac;
        public Ocenljivo Primalac
        {
            get { return primalac; }
        }
        private int primalacId { get { return primalac.ID; } set { } }

        private Korisnik autor;
        public Korisnik Autor
        {
            get { return autor; }
        }
        private string autorEmail { get { return autor.Email; } set { } }

        private int vrednost;

        public Ocena(Ocenljivo primalac, Korisnik autor, int vrednost)
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
