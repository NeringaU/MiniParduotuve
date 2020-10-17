using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniParduotuve
{
    class Preke
    {
        public int PrekesId { get; }

        public string PrekesPavadinimas { get; }

        public double PrekesKaina { get; }

        public Preke(int prekesId, string prekesPavadinimas, double prekesKaina)
        {
            PrekesId = prekesId;
            PrekesPavadinimas = prekesPavadinimas;
            PrekesKaina = prekesKaina;
        }
    }
}
