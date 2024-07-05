using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    static public class OsobaController
    {

        static public Osoba? Read(int id)
        {
            foreach (Osoba o in DatabaseController.database.Osobe.Include(osoba => osoba.Izvodjac))
                if (o.Izvodjac.ID == id)
                    return o;
            return null;
        }

        static public Osoba Create(string ime, string prezime, string biografija, DateOnly datumRodjenja, string slikaurl)
        {
            Osoba o = new Osoba(IzvodjacController.GenerateID(), ime, prezime, biografija, datumRodjenja);
            o.SlikaUrl = slikaurl;
            DatabaseController.database.Osobe.Add(o);
            DatabaseController.database.SaveChanges();
            return o;
        }

        static public void Update(int id, Osoba o2)
        {
            Osoba? o = Read(id);
            if (o == null)
                return;

            o.Ime = o2.Ime;
            o.Prezime = o2.Prezime;
            o.Biografija = o2.Biografija;
            o.DatumRodjenja = o2.DatumRodjenja;
            DatabaseController.database.SaveChanges();
        }

        static public void Delete(int id)
        {
            Osoba? o = Read(id);
            if (o == null)
                return;
            DatabaseController.database.Osobe.Remove(o);
            DatabaseController.database.SaveChanges();
        }

        static public List<Osoba> Filter(string? ime, string? prezime)
        {
            List<Osoba> sveOsobe = new List<Osoba>();
            foreach (Osoba o in DatabaseController.database.Osobe.Include(osoba => osoba.Izvodjac))
                sveOsobe.Add(o);

            if (ime != null)
                foreach (Osoba o in sveOsobe.ToList())
                    if (!o.Ime.ToLower().Contains(ime.ToLower()))
                        sveOsobe.Remove(o);

            if (prezime != null)
                foreach (Osoba o in sveOsobe.ToList())
                    if (!o.Prezime.ToLower().Contains(prezime.ToLower()))
                        sveOsobe.Remove(o);

            return sveOsobe;
        }

        static public List<Osoba> GetOsobeNaDelu(int deloId)
        {
            List<Osoba> osobe = new List<Osoba>();

            MuzickoDelo? md = MuzickoDeloController.Read(deloId);
            if(md == null)
                return osobe;

            foreach(Izvodjac i in md.Izvodjaci)
            {
                Osoba? o = Read(i.ID);
                if (o != null)
                    osobe.Add(o);
            }

            return osobe;
        }
    }
}
