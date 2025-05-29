using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ProjektRowery
{
    public enum Typ { standardowy, elektryczny }
    public enum StatusRoweru { dostepny, wypozyczony, serwisowany }

    public class Rower
    {
        public int id;
        public Typ typ;
        private StatusRoweru status;
        private string marka;
       
        public Rower(int id, Typ typ, string marka)
        {
            this.id = id;
            this.typ = typ;
            this.status = StatusRoweru.dostepny;
            this.marka = marka;
        }

        public string Marka()
        {
            return this.marka;
        }

        public void Wypozycz()
        {
            if (this.status == StatusRoweru.dostepny)
            {
                Console.WriteLine("Pomyślnie wypożyczono rower!");
                this.status = StatusRoweru.wypozyczony;
            }
            else
            {
                Console.WriteLine("Rower nie jest dostępny do wypożyczenia.");
            }
        }

        public string SprawdzStan()
        {
            return $"{this.status}";
        }

        public void ZglosUsterke()
        {
            this.status = StatusRoweru.serwisowany;
        }

        public void zwrocRower()
        {
            if (this.status != StatusRoweru.dostepny)
            {
                this.status = StatusRoweru.dostepny;
                Console.WriteLine("Pomyślnie zwrócono rower");
            }
            else
            {
                Console.WriteLine("Błąd, nie mozesz zwrocic dostępnego roweru");
            }

        }
    }
}
