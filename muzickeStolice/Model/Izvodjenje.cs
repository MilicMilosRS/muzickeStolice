using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Izvodjenje
    {
        public Izvodjenje() { }

        public int Id
        {
            get { return Ocenljivo.ID; }
            set { Ocenljivo.ID = value; }
        }
        public Ocenljivo Ocenljivo { get; set; }

        private int deloID;
        public int DeloID
        {
            get { return deloID; }
            set { deloID = value; }
        }

        private DateOnly datum;
        public DateOnly Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        private string opis;

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private List<Izvodjac> izvodjaci;
        public List<Izvodjac> Izvodjaci
        {
            get { return izvodjaci; }
        }

        public Izvodjenje(Ocenljivo id, int deloID, DateOnly datum, string opis)
        {
            Ocenljivo = id;
            this.deloID = deloID;
            this.datum = datum;
            this.opis = opis;
            this.izvodjaci = new List<Izvodjac>();
        }
    }
}
