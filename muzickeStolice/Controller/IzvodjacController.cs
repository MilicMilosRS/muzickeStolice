using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class IzvodjacController
    {
        private static List<Izvodjac> identifikatori = new List<Izvodjac>();

        public static Izvodjac GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (Izvodjac o in identifikatori)
                {
                    if (o.ID == i)
                    {
                        taken = true;
                        break;
                    }
                }
                if (!taken)
                {
                    Izvodjac o = new Izvodjac();
                    o.ID = i;
                    identifikatori.Add(o);
                    return o;
                }
            }
        }
    }
}
