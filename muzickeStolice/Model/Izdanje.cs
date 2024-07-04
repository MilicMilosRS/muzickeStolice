using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Izdanje
    {
        public Izdanje() { }
        public int Id
        {
            get;
            set;
        }
        public Ocenljivo Ocenljivo { get; set; }

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

        public Izdanje(Ocenljivo id, int deloID, TipIzdanja tip, DateOnly datumIzdanja)
        {
            Ocenljivo = id;
            Id = Ocenljivo.ID;
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
