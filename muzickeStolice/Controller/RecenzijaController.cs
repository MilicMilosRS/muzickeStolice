using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class RecenzijaController
    {
        static private List<Recenzija> _data = new List<Recenzija>();

        static public Recenzija? Read(Ocena o)
        {
            foreach (Recenzija r in _data)
                if (r.Ocena == o)
                    return r;
            return null;
        }

        static public Recenzija Create(Ocena o, string tekst)
        {
            Recenzija r = new Recenzija(tekst, o);
            _data.Add(r);
            return r;
        }

        static public void Update(Ocena o, string tekst)
        {
            Recenzija? r = Read(o);
            if (r == null)
                return;
            r.Tekst = tekst;
        }
    }
}
