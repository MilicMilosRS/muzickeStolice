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
        private static List<Ocenljivo> identifikatori = new List<Ocenljivo>();

        public static Ocenljivo GenerateID()
        {
            for(int i = 0; ; i++)
            {
                bool taken = false;
                foreach(Ocenljivo o in  identifikatori)
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
                    identifikatori.Add(o);
                    return o;
                }
            }
        }

    }
}
