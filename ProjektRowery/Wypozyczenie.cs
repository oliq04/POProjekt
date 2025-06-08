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
                
                Console.WriteLine($"Wypożyczenie zakończone. Rower ID: {rower.id} zwrócono o {czasZwrotu}");
            }
          
        }

        public int ObliczCzas()
        {
            if (czasZwrotu != null)
            {
                var span = (DateTime)czasZwrotu - czasWypozyczenia;
                return (int)span.TotalMinutes;
            }
            else
            {
                Console.WriteLine("Rower nie został jeszcze zwrócony.");
                return 0;
            }
        }
    }
}
