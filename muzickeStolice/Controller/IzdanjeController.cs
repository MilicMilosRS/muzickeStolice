using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class IzdanjeController
    {
        private static List<Izdanje> _data = new List<Izdanje>();
        static private int GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (Izdanje b in _data)
                    if (b.ID == i)
                    {
                        taken = true;
                        break;
                    }
                if (!taken)
                    return i;
            }
        }

        static public Izdanje? Read(int id)
        {
            foreach (Izdanje i in _data)
                if (i.ID == id)
                    return i;
            return null;
        }

        static public Izdanje Create(int deloId, TipIzdanja tip, DateOnly datumIzdanja)
        {
            if (MuzickoDeloController.Read(deloId) == null)
                throw new ArgumentException("Ne postoji muzicko delo sa tim identifikatorom");
            Izdanje i = new Izdanje(GenerateID(), deloId, tip, datumIzdanja);
            _data.Add(i);
            return i;
        }

        static public void Update(int id, Izdanje i2)
        {
            Izdanje? i = Read(id);
            if (i == null)
                return;
            i.DeloID = i2.DeloID;
            i.Tip = i2.Tip;
            i.DatumIzdanja = i2.DatumIzdanja;
        }

        static public void Delete(int id)
        {
            Izdanje? i = Read(id);
            if (i == null)
                return;
            _data.Remove(i);
        }

    }
}
