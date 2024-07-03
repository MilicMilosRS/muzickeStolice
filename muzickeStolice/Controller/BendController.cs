using Microsoft.EntityFrameworkCore;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class BendController
    {
        static public Bend? Read(int id)
        {
            foreach (Bend b in DatabaseController.database.Bendovi.Include(b => b.Izvodjac).Include(b => b.clanovi))
                if (b.Izvodjac.ID == id)
                    return b;
            return null;
        }

        static public Bend Create(string naziv, string opis, DateOnly datumOsnivanja)
        {
            Bend b = new Bend(IzvodjacController.GenerateID(), naziv, opis, datumOsnivanja);
            DatabaseController.database.Bendovi.Add(b);
            DatabaseController.database.SaveChanges();
            return b;
        }

        static public void Update(int id, string naziv, string opis, DateOnly datumOsnivanja)
        {
            Bend? b = Read(id);
            if (b == null)
                return;

            b.Naziv = naziv;
            b.Opis = opis;
            b.DatumOsnivanja = datumOsnivanja;
            DatabaseController.database.SaveChanges();
        }

        static public void Delete(int id)
        {
            Bend? b = Read(id);
            if (b == null)
                return;

            DatabaseController.database.Bendovi.Remove(b);
            DatabaseController.database.SaveChanges();
        }

        static public List<Bend> Filter(string? ime)
        {
            List<Bend> sviBendovi = new List<Bend>();
            sviBendovi.AddRange(DatabaseController.database.Bendovi.Include(b => b.Izvodjac));

            if (ime != null)
                foreach (Bend b in sviBendovi.ToList())
                    if (!b.Naziv.Contains(ime))
                        sviBendovi.Remove(b);

            return sviBendovi;
        }

        static public List<Bend> GetBendoviSaOsobom(int osobaId)
        {
            List<Bend> bendovi = new List<Bend>();

            foreach(Bend b in DatabaseController.database.Bendovi.Include(b => b.clanovi))
                foreach (Osoba o in b.clanovi)
                    if (o.ID == osobaId)
                        bendovi.Add(b);

            return bendovi;
        }

        static public List<Bend> GetBendoviNaDelu(int deloId)
        {
            List<Bend> bendovi = new List<Bend>();

            MuzickoDelo? md = MuzickoDeloController.Read(deloId);
            if (md == null)
                return bendovi;

            foreach(Izvodjac i in md.Izvodjaci)
            {
                Bend? b = Read(i.ID);
                if (b != null)
                    bendovi.Add(b);
            }

            return bendovi;
        }
    }
}
