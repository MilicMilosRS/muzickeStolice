using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class IzdanjeIzvodjenja
    {
        public IzdanjeIzvodjenja() { }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int izvodjenjeID;
        public int IzvodjenjeID
        {
            get { return izvodjenjeID; }
            set { izvodjenjeID = value; }
        }

        private string opis;
        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private string url;

        public IzdanjeIzvodjenja(int id, int izvodjenjeID, string opis, string url)
        {
            this.id = id;
            this.izvodjenjeID = izvodjenjeID;
            this.opis = opis;
            this.url = url;
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}
