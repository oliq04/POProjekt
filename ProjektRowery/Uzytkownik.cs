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
        private string imie;
        private string nazwisko;
        private List<Rower> historiaWypozyczen;
        private double saldo;
        

        public Uzytkownik(string imie, string nazwisko)
        {
            this.id = ostatnieId++;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.historiaWypozyczen = new List<Rower>();
            this.saldo = 0.0; // Inicjalizacja salda użytkownika

        }

        public void UserInfo()
        {
            Console.WriteLine($"Imie: {this.imie} \nNazwisko: {this.nazwisko} \nSaldo: {this.saldo}");
        }
            
        public void WypozyczRower(StacjaRowerowa stacja, Rower rower) 
        {
            if (rower.SprawdzStan() == "dostepny")
            {
                rower.Wypozycz();

                stacja.UsunZListyDostepnych(rower);

                historiaWypozyczen.Add(rower);
                Console.WriteLine($"{imie} wypożyczył rower ID: {rower.id} {rower.Marka()}");
            }
            else
            {
                Console.WriteLine("Nie można wypożyczyć roweru, ponieważ nie jest dostępny. Wybierz spośród dostępnych:");
            }
        }

        public void ZwrocRower(StacjaRowerowa stacja,Rower rower)
        {
            rower.zwrocRower();
            stacja.DodajDoListyDostepnych(rower);
            Console.WriteLine($"{imie} zwrócił rower ID: {rower.id} {rower.Marka()}");
        }

        public void WyswietlHistorie()
        {
            Console.WriteLine($"Historia wypożyczeń użytkownika {imie} {nazwisko}");
            foreach (var rower in historiaWypozyczen)
            {
                Console.WriteLine($"Rower ID: {rower.id}, Typ: {rower.typ}, Status: {rower.SprawdzStan()}");
            }
        }

        public void DodajSaldo(double kwota)
        {
            if (kwota > 0)
            {
                saldo += kwota;
                Console.WriteLine($"Dodano {kwota} do salda użytkownika {imie} {nazwisko}. Aktualne saldo: {saldo}");
            }
            else
            {
                Console.WriteLine("Kwota musi być większa od zera.");
            }
        }

        public void WypiszSaldo()
        {
            Console.WriteLine($"Aktualne saldo użytkownika {imie} {nazwisko}: {saldo}");
        }

        public void OplacRower(double koszt) //ObliczKwote()
        {
            if (saldo >= koszt)
            {
                saldo -= koszt;
                Console.WriteLine($"Opłacono rower. Koszt: {koszt}. Pozostałe saldo: {saldo}");
            }
            else
            {
                Console.WriteLine("Niewystarczające saldo do opłacenia roweru.");
            }
        }


    }
}
