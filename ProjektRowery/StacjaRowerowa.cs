using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    public class StacjaRowerowa
    {
        public List<Rower> ListaRowerow { get; private set; }

        public int LiczbaMiejsc { get; private set; }

        public List<(string NazwaStacji, string NazwaMiasta)> StacjeInfo { get; private set; }
            = new List<(string NazwaStacji, string NazwaMiasta)>();

        public int LiczbaWolnychMiejsc => LiczbaMiejsc - ListaRowerow.Count;

        public StacjaRowerowa(int liczbaMiejsc, string nazwaStacji, string nazwaMiasta, List<Rower> poczatkoweRowery)
        {
            LiczbaMiejsc = liczbaMiejsc;
            ListaRowerow = poczatkoweRowery;
            StacjeInfo.Add((nazwaStacji, nazwaMiasta));
        }

        public void UsunZListyDostepnych(Rower rower)
        {
            ListaRowerow.Remove(rower);
        }
    

        public bool CzyMoznaOddacRower()
        {
            return LiczbaWolnychMiejsc > 0;
        }

        public  bool czyMoznaWypozyczycRower(Rower nazwa)
        {
            return ListaRowerow.Contains(nazwa);
        }

        public void roweryNaStacji()
        {
            Console.WriteLine("Dostepne rowery na stacji:");
            foreach (var row in ListaRowerow)
            {
                Console.WriteLine(row.Marka());
            }
        }

    }
}
