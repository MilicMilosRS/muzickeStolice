using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class OcenljivoController
    {
        public static Ocenljivo GenerateID()
        {
            for(int i = 0; ; i++)
            {
                bool taken = false;
                foreach(Ocenljivo o in DatabaseController.database.Ocenljivosti)
                {
                    if(o.ID == i)
                    {
                        taken = true;
                        break;
                    }
                }
                if (!taken)
                {
                    Ocenljivo o = new Ocenljivo();
                    o.ID = i;
                    DatabaseController.database.Ocenljivosti.Add(o);
                    DatabaseController.database.SaveChanges();
                    return o;
                }
            }
        }

        public static string GetNazivDela(Ocenljivo o)
        {
            MuzickoDelo? md = MuzickoDeloController.Read(o.ID);
            if (md != null)
                return md.Naziv;

            Izvodjenje? izv = IzvodjenjeController.Read(o.ID);
            if (izv != null)
            {
                MuzickoDelo? imd = MuzickoDeloController.Read(o.ID);
                if (imd != null)
                    return imd.Naziv + " " + izv.Datum.ToString();
            }

            Izdanje? izd = IzdanjeController.Read(o.ID);
            if (izd != null)
            {
                MuzickoDelo? imd = MuzickoDeloController.Read(o.ID);
                if (imd != null)
                    return imd.Naziv + " " + izd.Tip.ToString() + " " + izd.DatumIzdanja.ToString();
            }

            return "";
        }
    }
}
