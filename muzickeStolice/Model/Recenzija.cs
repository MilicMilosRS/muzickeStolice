using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Recenzija
    {
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

        public Ocena Ocena
        {
            get { return ocena; }
        }
    }
}
