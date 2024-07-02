using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class MuzickoDelo : IOcenljivo
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private Zanr zanrDela;
        public Zanr ZanrDela
        {
            get { return zanrDela; }
            set { zanrDela = value; }
        }

        private string opis;
        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private TipDela tip;

        private List<IIzvodjac> izvodjaci;
        public List<IIzvodjac> Izvodjaci
        {
            get { return izvodjaci; }
        }

        public MuzickoDelo(int id, string naziv, Zanr z, string opis, TipDela tip)
        {
            this.id = id;
            this.naziv = naziv;
            this.zanrDela = z;
            this.opis = opis;
            this.tip = tip;
            this.izvodjaci = new List<IIzvodjac>();
        }

        public TipDela Tip
        {
            get { return tip; }
            set { tip = value; }
        }


    }
}
