using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class MuzickoDelo
    {
        public MuzickoDelo() { }


        public int Id { get { return Ocenljivo.ID; } set { Ocenljivo.ID = value; } }
        public Ocenljivo Ocenljivo { get; set; }

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

        private List<Izvodjac> izvodjaci;
        public List<Izvodjac> Izvodjaci
        {
            get { return izvodjaci; }
        }

        public MuzickoDelo(Ocenljivo id, string naziv, Zanr z, string opis, TipDela tip)
        {
            Ocenljivo = id;
            this.naziv = naziv;
            this.zanrDela = z;
            this.opis = opis;
            this.tip = tip;
            this.izvodjaci = new List<Izvodjac>();
        }

        public TipDela Tip
        {
            get { return tip; }
            set { tip = value; }
        }


    }
}
