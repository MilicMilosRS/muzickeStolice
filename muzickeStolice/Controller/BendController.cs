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

        public static Bend Create(string naziv, string opis, DateOnly datumOsnivanja, List<Osoba> clanovi)
        {
            Bend bend = new Bend()
            {
                Naziv = naziv,
                Opis = opis,
                DatumOsnivanja = datumOsnivanja,
                clanovi = clanovi
            };
            DatabaseController.database.Bendovi.Add(bend);
            DatabaseController.database.SaveChanges();

            return bend;
        }

        public static void Update(int id, string naziv, string opis, DateOnly datumOsnivanja, List<Osoba> clanovi)
        {
            Bend bend = DatabaseController.database.Bendovi.Include(b => b.clanovi).FirstOrDefault(b => b.Id == id);
            if (bend != null)
            {
                bend.Naziv = naziv;
                bend.Opis = opis;
                bend.DatumOsnivanja = datumOsnivanja;
                bend.clanovi = clanovi;
                DatabaseController.database.SaveChanges();
            }
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
