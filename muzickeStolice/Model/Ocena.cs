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
            set { primalac = value; }
        }
        public int primalacId { get; set; }

        private Korisnik autor;
        public Korisnik Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public string autorEmail { get; set; }

        private int vrednost;

        public Ocena(Ocenljivo primalac, Korisnik autor, int vrednost)
        {
            this.primalac = primalac;
            primalacId = primalac.ID;
            this.autor = autor;
            autor.Email = autor.Email;
            this.vrednost = vrednost;
        }

        public int Vrednost
        {
            get { return vrednost; }
            set { vrednost = value; }
        }
    }
}
