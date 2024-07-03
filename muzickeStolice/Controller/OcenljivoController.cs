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

    }
}
