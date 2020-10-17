using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniParduotuve
{
    class Siunta
    {
   
        public enum SiuntosDydis
        {
            Small=0,
            Medium=1,
            Large=2,
        }

        public enum SiuntimoBudas
        {
            SiuntimasInamusPerPasta=0,
            SiuntimasInamusPerKurjeri=1,
            SiuntimasIpastomata=2,
            TarptautinisSiuntimas=3,

        }
        public SiuntosDydis Tipas{get;}

        public double SiuntosKaina { get; set; }

        public string PristatymoAdresas { get; set; }
        
        public SiuntimoBudas Budas { get; set; }

        public double uzsakymoSuma { get; set; }
        

        public Siunta(SiuntosDydis tipas, string pristatymoAdresas, SiuntimoBudas budas)
        {
            Tipas = tipas;
            PristatymoAdresas = pristatymoAdresas;
            Budas = budas;
        }


        public double SiuntosKainosApskaiciavimas(double uzsakymoSuma,SiuntosDydis Tipas)
        {
            if (uzsakymoSuma == 0)
            {
                throw new System.ArgumentOutOfRangeException("Uzsakymo suma negali buti 0");
            }
            else if (uzsakymoSuma > 30)
            {
                return SiuntosKaina = 0;
            }

            else if (Tipas == SiuntosDydis.Small)
            {
                return SiuntosKaina = 2.99;
            }
            else if (Tipas == SiuntosDydis.Medium)
            {
                return SiuntosKaina = 5.99;
            }
            else if (Tipas == SiuntosDydis.Large)
            {
                return SiuntosKaina = 10.99;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Jusu pasiriktas siuntos tipas neegzistuoja");
            }

        }
    }
   

   

}
