using System.Diagnostics;

namespace ProjektRowery
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("\nWitaj w aplikacji wypożyczalni miejskiej rowerow!");
            Console.WriteLine("Aby wypożyczyć rower, zaloguj się na swoje konto, lub utwórz nowe!\n");

            Console.WriteLine("\n1.Utwórz nowe konto");
            Console.WriteLine("\n2.Zaloguj sie");

            int.TryParse(Console.ReadLine(), out int wybor);
            int id = 0;
            switch (wybor)
            {
                case 1:
                    Console.WriteLine("Podaj imie:");
                    string imie = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko:");
                    string nazwisko = Console.ReadLine();
                    
                    try
                    {
                        Uzytkownik user = new Uzytkownik(imie, nazwisko);
                        id++;
                        Console.WriteLine("Pomyslnie utworzono uzytkownika");
                    }

                    catch
                    {

                    }

                    break;

                case 2:
                   
                    break;

                default:
                    Console.WriteLine("Niepoprawana opcja");
                    break;




            }

            

        
           
           
            
        }
    }
}
