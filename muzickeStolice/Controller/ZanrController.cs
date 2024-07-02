using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class ZanrController
    {
        static private List<Zanr> _data = new List<Zanr>();

        static public Zanr? Read(string naziv)
        {
            foreach (Zanr z in _data)
                if (z.Naziv == naziv)
                    return z;
            return null;
        }

        static public Zanr Create(string naziv, string opis)
        {
            if (Read(naziv) != null)
                throw new ArgumentException("Vec postoji zanr sa tim nazivom");
            Zanr z = new Zanr(naziv, opis);
            _data.Add(z);
            return z;
        }

        static public void Update(string naziv, string opis)
        {
            Zanr? z = Read(naziv);
            if (z == null)
                return;
            z.Opis = opis;
        }

        static public void Delete(string naziv)
        {
            Zanr? z = Read(naziv);
            if (z == null)
                return;
            _data.Remove(z);
        }
    }
}
