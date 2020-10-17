using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniParduotuve
{
    class PrekiuKrepselis
    {
        public Preke preke { get; }
        public int kiekis { get; set; }
       

        public PrekiuKrepselis(Preke preke, int kiekis)
        {
            this.preke = preke;
            this.kiekis = kiekis;
           
        }


    }
}
