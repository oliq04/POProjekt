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

        public void WypiszSaldo(Uzytkownik user)
        {
            Console.WriteLine($"Saldo użytkownika {user.imie} {user.nazwisko}: {user.ZwrocSaldo()} zł");
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



    }
}
