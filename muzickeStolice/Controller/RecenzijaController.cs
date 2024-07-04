using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using muzickeStolice.Migrations;
using muzickeStolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace muzickeStolice.Controller
{
    static public class RecenzijaController
    {
        static public Recenzija? Read(Ocena o)
        {
            foreach (Recenzija r in DatabaseController.database.Recenzije.Include( r => r.Ocena))
                if (r.Ocena == o)
                    return r;
            return null;
        }

        static public Recenzija Create(Ocena o, string tekst)
        {
            Recenzija r = new Recenzija(tekst, o);
            DatabaseController.database.Recenzije.Add(r);
            DatabaseController.database.SaveChanges();
            return r;
        }

        static public void Update(Ocena o, string tekst)
        {
            Recenzija? r = Read(o);
            if (r == null)
                return;
            r.Tekst = tekst;
            r.Prihvacena = false;
            DatabaseController.database.SaveChanges();
        }

        static public void Delete(Ocena o)
        {
            Recenzija? r = Read(o);
            if (r == null)
                return;
            DatabaseController.database.Recenzije.Remove(r);
            DatabaseController.database.SaveChanges();
        }

        static public List<Recenzija> GetNeprihvacene()
        {
            List<Recenzija> rec = new List<Recenzija>();
            foreach (Recenzija r in DatabaseController.database.Recenzije.Include(r => r.Ocena))
                if (r.Prihvacena == false)
                    rec.Add(r);

            return rec;
        }
    }
}
