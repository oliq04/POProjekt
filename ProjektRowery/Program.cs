using System.Diagnostics;

namespace ProjektRowery
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Uzytkownik user2 = new Uzytkownik(2, "Kamil", "Wiertarka");
            Uzytkownik user3 = new Uzytkownik(3, "Oliwier", "Zyskowski");
            
            Rower Cross = new Rower(1, Typ.standardowy, "Cross");
            Rower Mountain = new Rower (2, Typ.standardowy, "Cube");
            Rower Elektryk = new Rower (3, Typ.standardowy, "Trek");
            Rower Sportowy = new Rower(4, Typ.standardowy, "Cube");
            Rower Wyczynowy = new Rower(5, Typ.standardowy, "Cross");
            Rower Miejski = new Rower(6, Typ.standardowy, "Bulls");
            Rower Dzieciecy = new Rower(7, Typ.standardowy, "Wigry");





            List<Rower> roweryPolitechnika = new List<Rower>();
            List<Rower> roweryAugustow = new List<Rower>();

            roweryPolitechnika.Add(Elektryk);
            roweryPolitechnika.Add (Mountain);
            roweryPolitechnika.Add(Cross);

            roweryAugustow.Add(Dzieciecy);
            roweryAugustow.Add(Miejski);
            roweryAugustow.Add(Wyczynowy);

            StacjaRowerowa StacjaAugustow = new StacjaRowerowa(5, "Stacja Postiw", "Augustow", roweryAugustow);
            StacjaRowerowa StacjaPolitechnika = new StacjaRowerowa(5, "Stacja Politechnika", "Białystok", roweryPolitechnika);

            StacjaPolitechnika.roweryNaStacji(StacjaPolitechnika);

            
            user2.WypozyczRower(StacjaPolitechnika,Cross);

            StacjaPolitechnika.roweryNaStacji(StacjaPolitechnika);

            user2.ZwrocRower(StacjaPolitechnika,Cross);

            StacjaPolitechnika.roweryNaStacji(StacjaPolitechnika);
            //user2.ZwrocRower(StacjaPolitechnika, Elektryk); //Tutaj powinno wyrzucic wyjatek w klasie Rower.cs bo pomimo ze jest błąd, to program dalej sie wykonuje










            /*
           Uzytkownik gabriel = new Uzytkownik(1, "Gabriel", "Stanowski");

           Rower rower0 = new Rower(1, Typ.standardowy);
           Rower rower1 = new Rower(2, Typ.standardowy);
           Rower rower2 = new Rower(3, Typ.standardowy);
           Rower rower3 = new Rower(4, Typ.elektryczny);

           rower1.ZglosUsterke();
           Console.WriteLine(rower1.SprawdzStan());
           rower1.Wypozycz();

           List<Rower> rowery = new List<Rower>();
           rowery.Add(rower0);


           StacjaRowerowa Stacja1 = new StacjaRowerowa(15,"Stacja na Pogodnej","Białystok", rowery);
           Stacja1.roweryNaStacji();


           Console.WriteLine("\nPróba wypożyczenia roweru0:");
           Wypozyczenie wypozyczenieGabriela = new Wypozyczenie(rower0);
           gabriel.WypozyczRower(rower0);
           Console.WriteLine($"Stan roweru0 po wypożyczeniu: {rower0.SprawdzStan()}");

           System.Threading.Thread.Sleep(22000); // 2 sekundy symulacji

           Console.WriteLine("\nPróba zwrotu roweru0:");
           wypozyczenieGabriela.ZakonczWypozyczenie();
           gabriel.ZwrocRower(rower0);
           Console.WriteLine($"Stan roweru0 po zwrocie: {rower0.SprawdzStan()}");

           Console.WriteLine($"\nCzas wypożyczenia roweru0: {wypozyczenieGabriela.ObliczCzas().TotalSeconds} sekund");
            */
        }
    }
}
