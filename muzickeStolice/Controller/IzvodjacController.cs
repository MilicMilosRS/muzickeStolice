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
        public static Izvodjac GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (Izvodjac o in DatabaseController.database.Izvodjaci)
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
                    DatabaseController.database.Izvodjaci.Add(o);
                    DatabaseController.database.SaveChanges();
                    return o;
                }
            }
        }
    }
}
