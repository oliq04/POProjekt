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

        public void Wypozycz(Rower rower, StacjaRowerowa stacja, Uzytkownik user)
        {
            if (rower.Status() == StatusRoweru.dostepny)
            {

                rower.UstawStatus(StatusRoweru.wypozyczony);
                stacja.UsunZListyDostepnych(rower);
                user.DodajWypozyczenie(rower, stacja);
                Console.WriteLine("\nPomyślnie wypożyczono rower!");

            }
            else
            {
                Console.WriteLine("\nRower nie jest dostępny do wypożyczenia.");
            }
        }

        public string SprawdzStan(Rower rower)
        {
            return $"{rower.Status}";
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
                Console.WriteLine("Zwrocono rower");

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
