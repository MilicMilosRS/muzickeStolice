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
        static private List<MuzickoDelo> _data = new List<MuzickoDelo>();

        static private int GenerateID()
        {
            for (int i = 0; ; i++)
            {
                bool taken = false;
                foreach (MuzickoDelo b in _data)
                    if (b.ID == i)
                    {
                        taken = true;
                        break;
                    }
                if (!taken)
                    return i;
            }
        }

        static public MuzickoDelo? Read(int id)
        {
            foreach (MuzickoDelo md in _data)
                if (md.ID == id)
                    return md;
            return null;
        }

        static public MuzickoDelo Create(string naziv, Zanr zanr, string opis, TipDela tip)
        {
            MuzickoDelo md = new MuzickoDelo(GenerateID(), naziv, zanr, opis, tip);
            _data.Add(md);
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
            md.Izvodjaci.AddRange(md2.Izvodjaci);
        }

        static public void Delete(int id)
        {
            MuzickoDelo? md = Read(id);
            if (md == null)
                return;
            _data.Remove(md);
        }
    }
}
