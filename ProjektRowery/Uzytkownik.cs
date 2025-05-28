using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    public class Uzytkownik
    {
        private int id;
        private string imie;
        private string nazwisko;
        private List<Rower> historiaWypozyczen;

        public Uzytkownik(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.historiaWypozyczen = new List<Rower>();
        }

        public void WypozyczRower(Rower rower)
        {
            if (rower.SprawdzStan() == "dostepny")
            {
                rower.Wypozycz();
                historiaWypozyczen.Add(rower);
                Console.WriteLine($"{imie} wypożyczył rower ID: {rower.SprawdzStan()}");
            }
            else
            {
                Console.WriteLine("Nie można wypożyczyć roweru, ponieważ nie jest dostępny.");
            }
        }

        public void ZwrocRower(Rower rower)
        {
            rower.zwrocRower();
            Console.WriteLine($"{imie} zwrócił rower ID: {rower.SprawdzStan()}");
        }

        public void WyswietlHistorie()
        {
            Console.WriteLine($"Historia wypożyczeń użytkownika {imie} {nazwisko}");
            foreach (var rower in historiaWypozyczen)
            {
                Console.WriteLine($"Rower ID: {rower.id}, Typ: {rower.typ}, Status: {rower.SprawdzStan()}");
            }
        }
    }
}
