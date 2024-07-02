using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    [PrimaryKey(nameof(primalacId),nameof(autorEmail))]
    public class Recenzija
    {
        public Recenzija() { }

        private string tekst;
        public string Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }

        private Ocena ocena;

        public Recenzija(string tekst, Ocena ocena)
        {
            this.tekst = tekst;
            this.ocena = ocena;
        }

        public int primalacId
        {
            get { return ocena.Primalac.ID; }
            set { }
        }
        public string autorEmail
        {
            get { return ocena.Autor.Email; }
            set { }
        }

        public Ocena Ocena
        {
            get { return ocena; }
        }
    }
}
