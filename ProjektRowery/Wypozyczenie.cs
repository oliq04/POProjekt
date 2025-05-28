using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    class Wypozyczenie
    {
        private DateTime czasWypozyczenia;
        private DateTime? czasZwrotu;
        private Rower rower;

        public Wypozyczenie(Rower rower)
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
                Console.WriteLine("Wypozyczenie zakończone");
            }
            else
            {
                Console.WriteLine("Wypozyczenie już wcześniej zakończono");
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
                Console.WriteLine("Rower nie został jeszcze zwrócony");
                return TimeSpan.Zero;
            }
        }
    }
}
