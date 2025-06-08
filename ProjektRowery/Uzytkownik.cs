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

        public void SetImie(string noweImie) => imie = noweImie;

        public void SetNazwisko(string noweNazwisko) => nazwisko = noweNazwisko;

        public void setSaldo(double noweSaldo)
        {
            if (noweSaldo < 0)
            {
                throw new ArgumentException("Saldo nie może być ujemne!", nameof(noweSaldo));
            }
            saldo = noweSaldo;
        }
        public List<Wypozyczenie> ShowHistory() => this.historiaWypozyczen;
        public List<Wypozyczenie> DodajWypozyczenie(Rower rower, StacjaRowerowa stacja)
        {
            this.historiaWypozyczen.Add(new Wypozyczenie(rower, stacja));
            return this.historiaWypozyczen;
        }
       
    } 

}
