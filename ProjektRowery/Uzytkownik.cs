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
        private string imie;
        private string nazwisko;
        private List<Wypozyczenie> historiaWypozyczen;
        private double saldo;
        public Uzytkownik(string imie, string nazwisko)
        {
            this.id = ostatnieId++;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.historiaWypozyczen = new List<Wypozyczenie>();
            this.saldo = 0.0;
        }
        
        public int GetID() => id;
        public string GetImie() => imie;
        public string GetNazwisko() => nazwisko;
        public double GetSaldo() => saldo;
        public List<Wypozyczenie> GetHistoriaWypozyczen() => historiaWypozyczen;

        internal void ZmienSaldo(double noweSaldo)
        {
            if (noweSaldo < 0)
                throw new ArgumentException("Saldo nie może być ujemne!", nameof(noweSaldo));
            saldo = noweSaldo;
        }
    }
}