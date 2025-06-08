using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRowery
{
    public class Uzytkownik
    {
        private static int ostatnieId = 0;
        private int id;
        public string imie { get; private set; }
        public string nazwisko { get; private set; }
        public List<Wypozyczenie> historiaWypozyczen { get; private set; } 

        private double saldo;

       

        public Uzytkownik(string imie, string nazwisko)
        {
            this.id = ostatnieId++;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.historiaWypozyczen = new List<Wypozyczenie>(); 
            this.saldo = 0.0;
        }

        public List<Wypozyczenie> ShowHistory() => this.historiaWypozyczen;

       
    }
}
