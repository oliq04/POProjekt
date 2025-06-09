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
            return user.GetSaldo();
        }

        public void WypiszSaldo(Uzytkownik user)
        {
            Console.WriteLine($"Saldo użytkownika {user.GetImie()} {user.GetNazwisko()}: {user.GetSaldo()} zł");
        }

        public void DodajSaldo(Uzytkownik user, double kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera.", nameof(kwota));

            user.ZmienSaldo(user.GetSaldo() + kwota);
            Console.WriteLine($"Dodano {kwota} zł. Nowe saldo: {user.GetSaldo()} zł");
        }

        public void Oplac(Uzytkownik user, double kwota)
        {
            if (kwota <= -1)
                throw new ArgumentException("Kwota musi być większa od zera.", nameof(kwota));

            user.ZmienSaldo(user.GetSaldo() - kwota);
            Console.WriteLine($"Zmniejszono saldo o {kwota} zł. Nowe saldo: {user.GetSaldo()} zł");
        }
        

        public void DodajWypozyczenie(Uzytkownik user, Rower rower, StacjaRowerowa stacja)
        {
            if (user == null || rower == null || stacja == null)
            {
                Console.WriteLine("Błąd: Nieprawidłowe dane wypożyczenia.");
                return;
            }

            user.GetHistoriaWypozyczen().Add(new Wypozyczenie(rower));
            Console.WriteLine($"Dodano wypożyczenie roweru ID {rower.GetId()} dla użytkownika {user.GetImie()} {user.GetNazwisko()} ze stacji {stacja.GetId()} | ID stacji: {stacja.GetId()}.");
        }

        public void WyswietlHistorie(Uzytkownik user)
        {
            Console.WriteLine($"Historia wypożyczeń użytkownika {user.GetImie()} {user.GetNazwisko()}:");

            if (user.GetHistoriaWypozyczen().Count == 0)
            {
                Console.WriteLine("Brak wypożyczeń.");
                return;
            }

            foreach (var wypozyczenie in user.GetHistoriaWypozyczen())
            {
                string statusZwrotu = wypozyczenie.GetCzasZwrotu() == null ? "Wciąż wypożyczony" : $"Zwrócono {wypozyczenie.GetCzasZwrotu()}";
                Console.WriteLine($"Rower ID: {wypozyczenie.GetRower().GetId()}, Typ: {wypozyczenie.GetRower().GetTyp()}, Wypożyczono: {wypozyczenie.GetCzasWypozyczenia()}, Status: {statusZwrotu}");
            }
        }
    }
}
