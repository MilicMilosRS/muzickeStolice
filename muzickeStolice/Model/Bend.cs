using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public class Bend : IIzvodjac, IOcenljivo
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

        private string opis;
        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        private DateOnly datumOsnivanja;

        public Bend(int id, string naziv, string opis, DateOnly datumOsnivanja)
        {
            this.id = id;
            this.naziv = naziv;
            this.opis = opis;
            this.datumOsnivanja = datumOsnivanja;
        }

        private DateOnly DatumOsnivanja
        {
            get { return datumOsnivanja; }
            set { datumOsnivanja = value; }
        }
    
        public void View(IIzvodjacVisitor visitor)
        {
            visitor.ViewBend(this);
        }
    }
}
