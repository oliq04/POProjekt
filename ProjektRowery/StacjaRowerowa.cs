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

        private int id;
        private List<Rower> ListaRowerow;
        private int LiczbaMiejsc;
        private string NazwaStacji;
        private string NazwaMiasta;
        private int LiczbaWolnychMiejsc => LiczbaMiejsc - ListaRowerow.Count;

        public StacjaRowerowa(int Id, int liczbaMiejsc, string nazwaStacji, string nazwaMiasta, List<Rower> poczatkoweRowery)
        {
            this.id = Id;
            this.LiczbaMiejsc = liczbaMiejsc;
            this.ListaRowerow = poczatkoweRowery ?? new List<Rower>(); 
            this.NazwaStacji = nazwaStacji;
            this.NazwaMiasta = nazwaMiasta;
        }

        public int GetId() => id;
        public int GetLiczbaMiejsc() => LiczbaMiejsc;
        public string GetNazwaStacji() => NazwaStacji;
        public string GetNazwaMiasta() => NazwaMiasta;
        public int GetLiczbaWolnychMiejsc() => LiczbaMiejsc - ListaRowerow.Count;
        public List<Rower> GetListaRowerow() => ListaRowerow;


        public static void WyswietlWszystkieStacje(List<StacjaRowerowa> listaStacji)
        {
            Console.WriteLine("\nLista wszystkich stacji:");
            foreach (var stacja in listaStacji)
            {
                Console.WriteLine($"ID: {stacja.GetId()}, {stacja.GetNazwaStacji()}, {stacja.GetNazwaMiasta()} – {stacja.GetLiczbaWolnychMiejsc()} wolnych miejsc");
            }
        }
        public void UsunZListyDostepnych(Rower rower)
        {
            if (ListaRowerow.Contains(rower))
            {
                ListaRowerow.Remove(rower);
                Console.WriteLine($"Rower ID: {rower.GetId()} został wypożyczony ze stacji {NazwaStacji}.");
            }
            else
            {
                Console.WriteLine($"Rower ID: {rower.GetId()} nie znajduje się na stacji {NazwaStacji}.");
            }
        }
        public void DodajDoListyDostepnych(Rower rower)
        {
            if (LiczbaWolnychMiejsc > 0)
            {
                ListaRowerow.Add(rower);
                Console.WriteLine($"Rower ID: {rower.GetId()} dodano do stacji {GetNazwaStacji()}.");
            }
            else
            {
                throw new StacjaPrzepelnionaException("\nStacja jest przepełniona! Udaj się do innej, lub spróbuj ponownie za jakiś czas...");
            }
        }


        public bool CzyMoznaOddacRower() => GetLiczbaWolnychMiejsc() > 0;
        public bool CzyMoznaWypozyczycRower(Rower rower) => ListaRowerow.Contains(rower);

        public void WyswietlDostepneRowery()
        {
            Console.WriteLine($"\nDostępne rowery na stacji {GetNazwaStacji()} ({GetNazwaMiasta()}) | ID stacji: {GetId()}:");
            foreach (var rower in ListaRowerow)
            {
                Console.WriteLine($"ID: {rower.GetId()}, Typ: {rower.GetTyp()}, Marka: {rower.GetMarka()}");
            }
        }
    }
}
