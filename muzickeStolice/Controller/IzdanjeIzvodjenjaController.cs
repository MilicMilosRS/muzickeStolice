using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class IzdanjeIzvodjenjaController
    {
        private static List<IzdanjeIzvodjenja> _data = new List<IzdanjeIzvodjenja>();

        static private int GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (IzdanjeIzvodjenja b in _data)
                    if (b.ID == i)
                    {
                        taken = true;
                        break;
                    }
                if (!taken)
                    return i;
            }
        }

        static public IzdanjeIzvodjenja? Read(int id)
        {
            foreach (IzdanjeIzvodjenja ii in _data)
                if (ii.ID == id)
                    return ii;
            return null;
        }

        static public IzdanjeIzvodjenja Create(int izvodjenjeId, string opis, string url)
        {
            if (IzvodjenjeController.Read(izvodjenjeId) == null)
                throw new ArgumentException("Ne postoji izvodjenje sa tim identifikatorom");
            IzdanjeIzvodjenja ii = new IzdanjeIzvodjenja(GenerateID(), izvodjenjeId, opis, url);
            _data.Add(ii);
            return ii;
        }

        static public void Update(int id, IzdanjeIzvodjenja ii2)
        {
            IzdanjeIzvodjenja? ii = Read(id);
            if (ii == null)
                return;
            ii.Opis = ii2.Opis;
            ii.Url = ii2.Url;
        }

        static public void Delete(int id)
        {
            IzdanjeIzvodjenja ii = Read(id);
            if (ii == null)
                return;
            _data.Remove(ii);
        }
    }
}
