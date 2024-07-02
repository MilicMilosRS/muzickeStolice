using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Zanr
    {
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private string opis;

        public Zanr(string naziv, string opis)
        {
            this.naziv = naziv;
            this.opis = opis;
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }
    }
}
