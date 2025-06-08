using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    class RowerService
    {

        public RowerService ()
        {

        }
        public void Wypozycz(Rower rower, StacjaRowerowa stacja, Uzytkownik user, UzytkownikService userService)
        {
            if (rower.GetStatus() == StatusRoweru.dostepny)
            {
                userService.DodajWypozyczenie(user, rower, stacja);
                rower.ZmienStatus(StatusRoweru.wypozyczony);
                stacja.UsunZListyDostepnych(rower);
                
                Console.WriteLine("\nPomyślnie wypożyczono rower!");

            }
            else
            {
                Console.WriteLine("\nRower nie jest dostępny do wypożyczenia.");
            }
        }

        public string SprawdzStan(Rower rower)
        {
            return rower.GetStatus().ToString();
        }

        public void ZglosUsterke(Rower rower)
        {
            rower.ZmienStatus(StatusRoweru.serwisowany);
        }

        public void zwrocRower(Rower rower, StacjaRowerowa stacja, Uzytkownik user)
        {
            if (rower.GetStatus() == StatusRoweru.wypozyczony)
            {
                rower.ZmienStatus(StatusRoweru.dostepny);
                stacja.DodajDoListyDostepnych(rower);

                var ostatnieWypozyczenie = user.GetHistoriaWypozyczen().LastOrDefault(wypozyczenie => wypozyczenie.GetRower() == rower && wypozyczenie.GetCzasZwrotu() == null);
                if (ostatnieWypozyczenie != null)
                {
                    ostatnieWypozyczenie.ZakonczWypozyczenie();
                }
                Console.WriteLine("\nRower pomyślnie zwrócono do stacji");

            }
            else
            {
                Console.WriteLine("\nBłąd, nie mozesz zwrocic dostępnego roweru");

            }
        }

    }
}
