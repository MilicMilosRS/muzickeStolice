using Microsoft.EntityFrameworkCore;
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
        static public Izdanje? Read(int id)
        {
            foreach (Izdanje i in DatabaseController.database.Izdanja.Include(i => i.Ocenljivo))
                if (i.Ocenljivo.ID == id)
                    return i;
            return null;
        }

        static public Izdanje Create(int deloId, TipIzdanja tip, DateOnly datumIzdanja)
        {
            if (MuzickoDeloController.Read(deloId) == null)
                throw new ArgumentException("Ne postoji muzicko delo sa tim identifikatorom");
            Izdanje i = new Izdanje(OcenljivoController.GenerateID(), deloId, tip, datumIzdanja);
            DatabaseController.database.Izdanja.Add(i);
            DatabaseController.database.SaveChanges();
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
            DatabaseController.database.SaveChanges();
        }

        static public void Delete(int id)
        {
            Izdanje? i = Read(id);
            if (i == null)
                return;
            DatabaseController.database.Izdanja.Remove(i);
            DatabaseController.database.SaveChanges();
        }

    }
}
