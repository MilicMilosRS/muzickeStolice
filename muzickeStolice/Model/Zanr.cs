using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    [PrimaryKey(nameof(Naziv))]
    public class Zanr
    {
        public Zanr() { }

        public string Naziv { get; set; }

        private string opis;

        public Zanr(string naziv, string opis)
        {
            Naziv = naziv;
            this.opis = opis;
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }
    }
}
