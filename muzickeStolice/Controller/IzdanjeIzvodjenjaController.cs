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
        static private int GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (IzdanjeIzvodjenja b in DatabaseController.database.IzdanjaIzvodjenja)
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
            foreach (IzdanjeIzvodjenja ii in DatabaseController.database.IzdanjaIzvodjenja)
                if (ii.ID == id)
                    return ii;
            return null;
        }

        static public IzdanjeIzvodjenja Create(int izvodjenjeId, string opis, string url)
        {
            if (IzvodjenjeController.Read(izvodjenjeId) == null)
                throw new ArgumentException("Ne postoji izvodjenje sa tim identifikatorom");
            IzdanjeIzvodjenja ii = new IzdanjeIzvodjenja(GenerateID(), izvodjenjeId, opis, url);
            DatabaseController.database.IzdanjaIzvodjenja.Add(ii);
            DatabaseController.database.SaveChanges();
            return ii;
        }

        static public void Update(int id, IzdanjeIzvodjenja ii2)
        {
            IzdanjeIzvodjenja? ii = Read(id);
            if (ii == null)
                return;
            ii.Opis = ii2.Opis;
            ii.Url = ii2.Url;
            DatabaseController.database.SaveChanges();
        }

        static public void Delete(int id)
        {
            IzdanjeIzvodjenja ii = Read(id);
            if (ii == null)
                return;
            DatabaseController.database.IzdanjaIzvodjenja.Remove(ii);
            DatabaseController.database.SaveChanges();
        }
    }
}
