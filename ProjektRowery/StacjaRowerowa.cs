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
        public string NazwaStacji { get; private set; }
        public string NazwaMiasta { get; private set; }

        public int LiczbaWolnychMiejsc => LiczbaMiejsc - ListaRowerow.Count;

        public StacjaRowerowa(int liczbaMiejsc, string nazwaStacji, string nazwaMiasta, List<Rower> poczatkoweRowery)
        {
            LiczbaMiejsc = liczbaMiejsc;
            ListaRowerow = poczatkoweRowery ?? new List<Rower>(); 
            NazwaStacji = nazwaStacji;
            NazwaMiasta = nazwaMiasta;
        }

        public void UsunZListyDostepnych(Rower rower)
        {
            if (ListaRowerow.Contains(rower))
            {
                ListaRowerow.Remove(rower);
                Console.WriteLine($"Rower ID: {rower.id} został wypożyczony ze stacji {NazwaStacji}.");
            }
            else
            {
                Console.WriteLine($"Rower ID: {rower.id} nie znajduje się na stacji {NazwaStacji}.");
            }
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

        public  bool czyMoznaWypozyczycRower(Rower rower)
        {
            return ListaRowerow.Contains(rower);
        }

        public void WyswietlDostepneRowery()
        {
            Console.WriteLine($"\nDostępne rowery na stacji {NazwaStacji} ({NazwaMiasta}):");
            foreach (var rower in ListaRowerow)
            {
                Console.WriteLine($"ID: {rower.id}, Typ: {rower.type()}, Marka: {rower.Marka()}");
            }
        }
    }
}
