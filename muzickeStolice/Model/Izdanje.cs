using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Izdanje : IOcenljivo
    {
        private int deloID;
        public int DeloID
        {
            get { return deloID; }
            set { deloID = value; }
        }

        private TipIzdanja tip;
        public TipIzdanja Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        private DateOnly datumIzdanja;

        public Izdanje(int deloID, TipIzdanja tip, DateOnly datumIzdanja)
        {
            this.deloID = deloID;
            this.tip = tip;
            this.datumIzdanja = datumIzdanja;
        }

        public DateOnly DatumIzdanja
        {
            get { return datumIzdanja; }
            set { datumIzdanja = value; }
        }

    }
}
