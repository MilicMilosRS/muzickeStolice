using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Model
{
    public interface IIzvodjacVisitor
    {
        void ViewOsoba(Osoba o);
        void ViewBend(Bend b);
    }
}
