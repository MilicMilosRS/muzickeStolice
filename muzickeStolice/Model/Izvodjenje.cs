using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Izvodjenje : IOcenljivo
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

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

        private List<IIzvodjac> izvodjaci;
        public List<IIzvodjac> Izvodjaci
        {
            get { return izvodjaci; }
        }

        public Izvodjenje(int id, int deloID, DateOnly datum, string opis)
        {
            this.id = id;
            this.deloID = deloID;
            this.datum = datum;
            this.opis = opis;
            this.izvodjaci = new List<IIzvodjac>();
        }
    }
}
