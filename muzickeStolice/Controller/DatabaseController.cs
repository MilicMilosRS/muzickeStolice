using muzickeStolice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickeStolice.Controller
{
    public static class DatabaseController
    {
        public static AppDbContext database = new AppDbContext();
    }
}
