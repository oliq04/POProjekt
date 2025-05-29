using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    public class StacjaRowerowaExceptions : Exception
    {
        public StacjaRowerowaExceptions() { }
        public StacjaRowerowaExceptions(string message) : base(message) { }


    }

    public class StacjaPrzepelnionaException : StacjaRowerowaExceptions
    {
        public StacjaPrzepelnionaException() { }
        public StacjaPrzepelnionaException(string message):base(message) { }
    }



    public class StacjaRowerowa
    {

        public List<Rower> ListaRowerow { get; private set; }

        public int LiczbaMiejsc { get; private set; }

        public List<(string NazwaStacji, string NazwaMiasta)> StacjeInfo { get; private set; }
            = new List<(string NazwaStacji, string NazwaMiasta)>();

        public int LiczbaWolnychMiejsc => LiczbaMiejsc - ListaRowerow.Count;

        private string nazwaStacji;
        private string nazwaMiasta;

        public StacjaRowerowa(int liczbaMiejsc, string nazwaStacji, string nazwaMiasta, List<Rower> poczatkoweRowery)
        {
            LiczbaMiejsc = liczbaMiejsc;
            ListaRowerow = poczatkoweRowery;
            StacjeInfo.Add((nazwaStacji, nazwaMiasta));
            this.nazwaStacji=nazwaStacji;
            this.nazwaMiasta= nazwaMiasta;
        }

        public void UsunZListyDostepnych(Rower rower)
        {
            ListaRowerow.Remove(rower);
        }
        public void DodajDoListyDostepnych(Rower rower)
        {
            if (LiczbaWolnychMiejsc > 0)
            {
                ListaRowerow.Add(rower);
            }
            else
            {
                throw new StacjaPrzepelnionaException("\nStacja jest przepełniona! Udaj się do innej, lub spróbuj ponownie za jakiś czas...");
            }
            
        }
    

        public bool CzyMoznaOddacRower()
        {
            return LiczbaWolnychMiejsc > 0;
        }

        public  bool czyMoznaWypozyczycRower(Rower nazwa)
        {
            return ListaRowerow.Contains(nazwa);
        }

        public void roweryNaStacji(StacjaRowerowa stacja)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Dostepne rowery na stacji {stacja.nazwaStacji} w mieście {stacja.nazwaMiasta}:");
            foreach (var row in ListaRowerow)
            {
                Console.WriteLine(row.Marka());
            }
        }

    }
}
