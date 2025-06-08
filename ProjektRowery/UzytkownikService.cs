using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    class UzytkownikService
    {

        public UzytkownikService()
        {

        }

        public double ZwrocSaldo(Uzytkownik user)
        {
            return user.saldo;
        }

        public void WypiszSaldo(Uzytkownik user)
        {
            Console.WriteLine($"Saldo użytkownika {user.imie} {user.nazwisko}: {user.saldo} zł");
        }

        public void DodajSaldo(Uzytkownik user, double kwota)
        {
            user.ZwiekszSaldo(kwota);
            Console.WriteLine($"Dodano {kwota} zł. Nowe saldo: {user.ZwrocSaldo()} zł");
        }

        public void Oplac(Uzytkownik user, double kwota)
        {
            user.ZmniejszSaldo(kwota);
            Console.WriteLine($"Zmniejszono saldo o {kwota} zł. Nowe saldo: {user.ZwrocSaldo()} zł");
        }
        public void WyswietlHistorie(Uzytkownik user)
        {
            Console.WriteLine($"Historia wypożyczeń użytkownika {user.imie} {user.nazwisko}:");

            if (user.ShowHistory().Count == 0)
            {
                Console.WriteLine("Brak wypożyczeń.");
                return;
            }

            foreach (var wypozyczenie in user.ShowHistory())
            {
                string statusZwrotu = wypozyczenie.czasZwrotu == null ? "Wciąż wypożyczony" : $"Zwrócono {wypozyczenie.czasZwrotu}";
                Console.WriteLine($"Rower ID: {wypozyczenie.rower.id}, Typ: {wypozyczenie.rower.type()}, Wypożyczono: {wypozyczenie.czasWypozyczenia}, {statusZwrotu}");
            }
        }

        public void DodajWypozyczenie(Uzytkownik user, Rower rower, StacjaRowerowa stacja)
        {
            if (user == null || rower == null || stacja == null)
            {
                Console.WriteLine("Błąd: Nieprawidłowe dane wypożyczenia.");
                return;
            }

            Wypozyczenie noweWypozyczenie = new Wypozyczenie(rower, stacja);
            user.historiaWypozyczen.Add(noweWypozyczenie);

            Console.WriteLine($"✔️ Dodano wypożyczenie roweru ID {rower.id} dla użytkownika {user.imie} {user.nazwisko} ze stacji {stacja.NazwaStacji} | ID stacji: {stacja.id}.");
        }
    }
}
