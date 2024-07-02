using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class BendController
    {
        static private List<Bend> _data = new List<Bend>();


        static public Bend? Read(int id)
        {
            foreach (Bend b in _data)
                if (b.Izvodjac.ID == id)
                    return b;
            return null;
        }

        static public Bend Create(string naziv, string opis, DateOnly datumOsnivanja)
        {
            Bend b = new Bend(IzvodjacController.GenerateID(), naziv, opis, datumOsnivanja);
            _data.Add(b);
            return b;
        }

        static public void Update(int id, string naziv, string opis, DateOnly datumOsnivanja)
        {
            Bend? b = Read(id);
            if (b == null)
                return;

            b.Naziv = naziv;
            b.Opis = opis;
            b.DatumOsnivanja = datumOsnivanja;
        }

        static public void Delete(int id)
        {
            Bend? b = Read(id);
            if (b == null)
                return;

            _data.Remove(b);
        }
    }
}
