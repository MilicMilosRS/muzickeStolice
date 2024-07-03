using Microsoft.EntityFrameworkCore;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class MuzickoDeloController
    {
        static public MuzickoDelo? Read(int id)
        {
            foreach (MuzickoDelo md in 
                DatabaseController.database.MuzickaDela.Include(d => d.Ocenljivo).Include(d => d.Izvodjaci).Include(d => d.ZanrDela))
                if (md.Ocenljivo.ID == id)
                    return md;
            return null;
        }

        static public MuzickoDelo Create(string naziv, Zanr zanr, string opis, TipDela tip)
        {
            MuzickoDelo md = new MuzickoDelo(OcenljivoController.GenerateID(), naziv, zanr, opis, tip);
            DatabaseController.database.MuzickaDela.Add(md);
            DatabaseController.database.SaveChanges();
            return md;
        }

        static public void Update(int id, MuzickoDelo md2)
        {
            MuzickoDelo? md = Read(id);
            if (md == null)
                return;
            md.Opis = md2.Opis;
            md.ZanrDela = md2.ZanrDela;
            md.Naziv = md2.Naziv;
            md.Tip = md2.Tip;
            md.Izvodjaci.Clear();
            foreach (Izvodjac i in md2.Izvodjaci)
                md.Izvodjaci.Add(i);
        }

        static public void Delete(int id)
        {
            MuzickoDelo? md = Read(id);
            if (md == null)
                return;
            DatabaseController.database.MuzickaDela.Remove(md);
            DatabaseController.database.SaveChanges();
        }
    }
}
