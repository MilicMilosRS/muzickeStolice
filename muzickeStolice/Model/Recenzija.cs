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
            this.primalacId = ocena.primalacId;
            this.autorEmail = ocena.autorEmail;
            this.ocena = ocena;
            Prihvacena = false;
        }

        public int primalacId { get; set; }
        public string autorEmail { get; set; }

        public Ocena Ocena
        {
            get { return ocena; }
            set { ocena = value; }
        }

        public Boolean Prihvacena { get; set; }
    }
}
