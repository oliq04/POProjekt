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

         public void DodajWypozyczenie(Rower rower, StacjaRowerowa stacja)
        {
            historiaWypozyczen.Add(new Wypozyczenie(rower, stacja));
        }
        public void WypozyczRower(StacjaRowerowa stacja, Rower rower, RowerService serwis)
        {
            if (rower.Status() == StatusRoweru.dostepny)
            {
                serwis.Wypozycz(rower);

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
