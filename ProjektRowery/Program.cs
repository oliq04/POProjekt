using System.Diagnostics;

namespace ProjektRowery
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Uzytkownik gabriel = new Uzytkownik(1, "Gabriel", "Stanowski");

            Rower rower0 = new Rower(1, Typ.standardowy);
            Rower rower1 = new Rower(2, Typ.standardowy);
            Rower rower2 = new Rower(3, Typ.standardowy);
            Rower rower3 = new Rower(4, Typ.elektryczny);

            rower1.ZglosUsterke();
            Console.WriteLine(rower1.SprawdzStan());
            rower1.Wypozycz();


            Console.WriteLine("\nPróba wypożyczenia roweru0:");
            gabriel.WypozyczRower(rower0);
            Console.WriteLine($"Stan roweru0 po wypożyczeniu: {rower0.SprawdzStan()}");

            // Test zwrotu roweru
            Console.WriteLine("\nPróba zwrotu roweru0:");
            gabriel.ZwrocRower(rower0);
            Console.WriteLine($"Stan roweru0 po zwrocie: {rower0.SprawdzStan()}");
        }
    }
}
