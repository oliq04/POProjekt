using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    public class Wypozyczenie
    {
        public DateTime czasWypozyczenia { get; private set; } // Tylko odczyt
        public DateTime? czasZwrotu { get; private set; } // Teraz dostępne do odczytu!
        public Rower rower { get; private set; } // Publiczny dostęp do roweru

        public Wypozyczenie(Rower rower, StacjaRowerowa stacjaRowerowa)
        {
            this.rower = rower;
            this.czasWypozyczenia = DateTime.Now;
            this.czasZwrotu = null;
        }

        public void ZakonczWypozyczenie()
        {
            if (czasZwrotu == null)
            {
                czasZwrotu = DateTime.Now;
                rower.zwrocRower();
                Console.WriteLine($"Wypożyczenie zakończone. Rower ID: {rower.id} zwrócono o {czasZwrotu}");
            }
            else
            {
                Console.WriteLine("Wypożyczenie już wcześniej zakończono.");
            }
        }

        public TimeSpan ObliczCzas()
        {
            if (czasZwrotu != null)
            {
                return ((DateTime)czasZwrotu - czasWypozyczenia);
            }
            else
            {
                Console.WriteLine("Rower nie został jeszcze zwrócony.");
                return TimeSpan.Zero;
            }
        }
    }
}
