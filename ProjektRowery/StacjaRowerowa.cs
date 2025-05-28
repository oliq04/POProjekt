using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    class StacjaRowerowa
    {
        public List<Rower> ListaRowerow { get; private set; }

        public int LiczbaMiejsc { get; private set; }

        public string NazwaStacji { get; private set; }

        public int LiczbaWolnychMiejsc => LiczbaMiejsc - ListaRowerow.Count;
        



        public StacjaRowerowa(int liczbaMiejsc, string nazwaStacji, List<Rower> poczatkoweRowery)
        {
            LiczbaMiejsc = liczbaMiejsc;
            NazwaStacji = nazwaStacji;
            ListaRowerow = poczatkoweRowery;
        }

        public bool CzyMoznaOddacRower()
        {
            return LiczbaWolnychMiejsc > 0;
        }

        public  bool czyMoznaWypozyczycRower(Rower nazwa)
        {
            return ListaRowerow.Contains(nazwa);
        }

        public List<Rower> roweryNaStacji()
        {
            return ListaRowerow;
        }

    }
}
