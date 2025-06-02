using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    public class Uzytkownik
    {
        private static int ostatnieId = 0;
        private int id;
        public string imie { get; private set; }
        public string nazwisko { get; private set; }
        public List<Wypozyczenie> historiaWypozyczen { get; private set; } 

        private double saldo;

        public Uzytkownik(string imie, string nazwisko)
        {
            this.id = ostatnieId++;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.historiaWypozyczen = new List<Wypozyczenie>(); 
            this.saldo = 0.0;
        }

        public void DodajWypozyczenie(Rower rower, StacjaRowerowa stacja)
        {
            historiaWypozyczen.Add(new Wypozyczenie(rower, stacja));
        }
        public void WypozyczRower(StacjaRowerowa stacja, Rower rower)
        {
            if (rower.SprawdzStan() == "dostepny")
            {
                rower.Wypozycz();
                stacja.UsunZListyDostepnych(rower);
                historiaWypozyczen.Add(new Wypozyczenie(rower, stacja)); 
                Console.WriteLine($"{imie} wypożyczył rower ID: {rower.id} {rower.Marka()} ze stacji {stacja.NazwaStacji}");
            }
            else
            {
                Console.WriteLine("Rower nie jest dostępny.");
            }
        }

        public void WypiszSaldo()
        {
            Console.WriteLine($"Saldo użytkownika {imie} {nazwisko}: {saldo} zł");
        }
        public void WyswietlHistorie()
        {
            Console.WriteLine($"Historia wypożyczeń użytkownika {imie} {nazwisko}:");

            if (historiaWypozyczen.Count == 0)
            {
                Console.WriteLine("Brak wypożyczeń.");
                return;
            }

            foreach (var wypozyczenie in historiaWypozyczen)
            {
                string statusZwrotu = wypozyczenie.czasZwrotu == null ? "Wciąż wypożyczony" : $"Zwrócono {wypozyczenie.czasZwrotu}";
                Console.WriteLine($"Rower ID: {wypozyczenie.rower.id}, Typ: {wypozyczenie.rower.typ}, Wypożyczono: {wypozyczenie.czasWypozyczenia}, {statusZwrotu}");
            }
        }
    }
}
