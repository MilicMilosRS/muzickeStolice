using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class IzvodjenjeController
    {
        public static List<Izvodjenje> _data = new List<Izvodjenje>();

        static public Izvodjenje? Read(int id)
        {
            foreach (Izvodjenje i in _data)
                if (i.Ocenljivo.ID == id)
                    return i;
            return null;
        }

        static public Izvodjenje Create(int deloId, DateOnly datum, string opis)
        {
            if (MuzickoDeloController.Read(deloId) == null)
                throw new ArgumentException("Ne postoji delo sa tim identifikatorom");
            Izvodjenje i = new Izvodjenje(OcenljivoController.GenerateID(), deloId, datum, opis);
            _data.Add(i);
            return i;
        }

        static public void Update(int id, Izvodjenje i2)
        {
            Izvodjenje? i = Read(id);
            if (i == null)
                return;
            i.Opis = i2.Opis;
            i.DeloID = i2.DeloID;
            i.Izvodjaci.Clear();
            i.Izvodjaci.AddRange(i2.Izvodjaci);
            i.Datum = i2.Datum;
        }

        static public void Delete(int id)
        {
            Izvodjenje? i = Read(id);
            if (i == null)
                return;
            _data.Remove(i);
        }
    }
}
