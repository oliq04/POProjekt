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

        public double saldo { get; set; }



        public Uzytkownik(string imie, string nazwisko)
        {
            this.id = ostatnieId++;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.historiaWypozyczen = new List<Wypozyczenie>();
            this.saldo = 0.0;
        }


        public void ZwiekszSaldo(double kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera.", nameof(kwota));
            saldo += kwota;
        }

        public void ZmniejszSaldo(double kwota)
        {
            if (kwota <= 0)
                throw new ArgumentException("Kwota musi być większa od zera.", nameof(kwota));
            saldo -= kwota;
        }
        public double ZwrocSaldo() => this.saldo;

        public List<Wypozyczenie> ShowHistory() => this.historiaWypozyczen;
        public List<Wypozyczenie> DodajWypozyczenie(Rower rower, StacjaRowerowa stacja)
        {
            this.historiaWypozyczen.Add(new Wypozyczenie(rower, stacja));
            return this.historiaWypozyczen;
        }
       
    } 

}
