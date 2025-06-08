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
        private DateTime czasWypozyczenia;
        private DateTime? czasZwrotu;
        private Rower rower;

        public Wypozyczenie(Rower rower, StacjaRowerowa stacjaRowerowa)
        {
            this.rower = rower;
            this.czasWypozyczenia = DateTime.Now;
            this.czasZwrotu = null;
        }
        public DateTime GetCzasWypozyczenia() => czasWypozyczenia;
        public DateTime? GetCzasZwrotu() => czasZwrotu;
        public Rower GetRower() => rower;
        public void ZakonczWypozyczenie()
        {
            if (czasZwrotu == null)
            {
                czasZwrotu = DateTime.Now;
                Console.WriteLine($"\nWypożyczenie zakończone. Rower ID: {rower.GetId()} zwrócono o {czasZwrotu}");
            }
            else
            {
                Console.WriteLine("\nWypożyczenie tego roweru już zostało zakończone.");
            }
        }

        public int ObliczCzas()
        {
            if (czasZwrotu == null)
            {
                throw new InvalidOperationException("\nRower nie został jeszcze zwrócony.");
            }

            var czasTrwania = (DateTime)czasZwrotu - czasWypozyczenia;
            return (int)czasTrwania.TotalMinutes;
        }
    }
}
