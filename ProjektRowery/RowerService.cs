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


        public string Marka(Rower rower)
        {
            return rower.Marka();
        }

        public void Wypozycz(Rower rower, StacjaRowerowa stacja, Uzytkownik user, UzytkownikService userService)
        {
            if (rower.Status() == StatusRoweru.dostepny)
            {
                userService.DodajWypozyczenie(user, rower, stacja);
                rower.UstawStatus(StatusRoweru.wypozyczony);
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
            return rower.Status().ToString();
        }

        public void ZglosUsterke(Rower rower)
        {
            rower.UstawStatus(StatusRoweru.serwisowany);
        }

        public void zwrocRower(Rower rower, StacjaRowerowa stacja, Uzytkownik user)
        {
            if (rower.Status() == StatusRoweru.wypozyczony)
            {
                rower.UstawStatus(StatusRoweru.dostepny);
                stacja.DodajDoListyDostepnych(rower);

                var ostatnieWypozyczenie = user.GetHistoriaWypozyczen().LastOrDefault(wypozyczenie => wypozyczenie.rower == rower && wypozyczenie.czasZwrotu == null);
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
        public Typ ZwrocTypEnum(Rower rower)
        {
            return rower.type();
        }
    }
}
