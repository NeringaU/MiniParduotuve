using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MiniParduotuve
{
    class Program
    {
        public static double SiuntimoIslaidos { get; set; }
        public static double GalutineUzsakymoSuma { get; set; }
        public static double TarpineUzsakymoSuma { get; set; }

        static void Main(string[] args)
        {
            List<PrekiuKrepselis> uzsakymas = new List<PrekiuKrepselis>();
            uzsakymas.Add(new PrekiuKrepselis(new Preke(1, "Vaikiskas Zaislas", 10.90), 1));
            uzsakymas.Add(new PrekiuKrepselis(new Preke(52, "Pagalve", 5.85), 2));
            uzsakymas.Add(new PrekiuKrepselis(new Preke(14, "Puodelis", 2.50), 2));


            ApskaiciuotiTarpineUzsakymoSuma(uzsakymas);
           
            Siunta naujaSiunta = new Siunta(Siunta.SiuntosDydis.Small, "Kaunas", Siunta.SiuntimoBudas.SiuntimasIpastomata);

            ApskaiciuotiSiuntimoIslaidas(naujaSiunta);

            ApskaiciuotiGalutineUzsakmoSuma(TarpineUzsakymoSuma, SiuntimoIslaidos);

            SpausdintiUzsakymoSuvestine(uzsakymas);

            Console.WriteLine();
            Console.WriteLine();
          
            UzsakymoApdorojimas();

            Console.Read();
        }

        public static double ApskaiciuotiTarpineUzsakymoSuma(List<PrekiuKrepselis> uzsakymas)
        {
            foreach (var i in uzsakymas)
            {

                var PrekesKaina = i.preke.PrekesKaina;
                var kiekis = i.kiekis;
                var UzsakymoSuma = PrekesKaina * kiekis;
                TarpineUzsakymoSuma = TarpineUzsakymoSuma + UzsakymoSuma;
            }
            return TarpineUzsakymoSuma;
        }

        public static double ApskaiciuotiSiuntimoIslaidas (Siunta newSiunta)
        {
            SiuntimoIslaidos = newSiunta.SiuntosKainosApskaiciavimas(TarpineUzsakymoSuma, newSiunta.Tipas);

            return SiuntimoIslaidos;

        }

        public static double ApskaiciuotiGalutineUzsakmoSuma(double tarpineUzsakymoSuma,double siuntimoIslaidos)
        {
            return GalutineUzsakymoSuma = tarpineUzsakymoSuma + siuntimoIslaidos;
        }

        public static void SpausdintiUzsakymoSuvestine(List<PrekiuKrepselis> uzsakymas)
        {
            Console.WriteLine("**********Aciu, kad apsilankete musu parduotuveje!****************");
            Console.WriteLine();
            Console.WriteLine("Jusu užsakymas:");
            Console.WriteLine();

            foreach (var i in uzsakymas)
            {
                Console.WriteLine($"PrekesID {i.preke.PrekesId}- {i.preke.PrekesPavadinimas} - {i.preke.PrekesKaina} eur/vnt - { i.kiekis} vnt");

            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Tarpine uzsakymo suma: {TarpineUzsakymoSuma} eur");
            Console.WriteLine($"Siuntimo islaidos: {SiuntimoIslaidos} eur");
            Console.WriteLine($"Galutinė užsakymo suma: {GalutineUzsakymoSuma} eur");
        }

        public static void UzsakymoApdorojimas()
        {
            Console.WriteLine("Noredami issiusti uzsakyma spauskite Y, noredami atsaukti spauskite N");

            var vartotojoPasirinkimas = Console.ReadLine();

            if (vartotojoPasirinkimas.ToUpper() == "Y")
            {
                Console.WriteLine("Jusu uzsakymas sekmingai isiustas.\n Aciu, kad pirkote <3 !");
            }
            else if (vartotojoPasirinkimas.ToUpper() == "N")
            {
                Console.WriteLine("Jusu uzsakymas sekmingai atsauktas.\n Lauksime sugriztant!");
            }
            else if (vartotojoPasirinkimas.ToUpper() != "Y" || vartotojoPasirinkimas.ToUpper() != "N")
            {
                Console.WriteLine("Tokio pasirinkimo nera! Noredami issiusti uzsakyma spauskite Y, noredami atsaykti spauskite N");
            }

        }
    }
}
