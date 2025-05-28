using System.Diagnostics;

namespace ProjektRowery
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Rower rower0 = new Rower(1, Typ.standardowy);
            Rower rower1 = new Rower(2, Typ.standardowy);
            Rower rower2 = new Rower(3, Typ.standardowy);
            Rower rower3 = new Rower(4, Typ.elektryczny);
            Console.WriteLine(rower1.SprawdzStan());
            rower1.Wypozycz();
            Console.WriteLine(rower1.SprawdzStan());

        }
    }
}
