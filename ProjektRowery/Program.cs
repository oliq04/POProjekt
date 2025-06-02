using System.Diagnostics;

namespace ProjektRowery
{
    internal class Program
    {
        static List<Uzytkownik> listaUzytkownikow = new List<Uzytkownik>();


        static void Main(string[] args)
        {
            Uzytkownik Tomasz = new Uzytkownik("Tomasz", "Problem");
            listaUzytkownikow.Add(Tomasz);

            Console.WriteLine("\nWitaj w aplikacji wypożyczalni miejskiej rowerow!");
            Console.WriteLine("Aby wypożyczyć rower, zaloguj się na swoje konto, lub utwórz nowe!\n");

            Console.WriteLine("\n1.Utwórz nowe konto");
            Console.WriteLine("2.Zaloguj sie");

            int.TryParse(Console.ReadLine(), out int wybor);
            
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
                        listaUzytkownikow.Add(user);
                        Console.WriteLine("Pomyslnie utworzono uzytkownika");
                    }

                    catch
                    {

                    }

                    break;

                case 2:
                    Console.WriteLine("Podaj imie:");
                    string imieLogin= Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko:");
                    string nazwiskoLogin = Console.ReadLine();

                    foreach (var uzyt in listaUzytkownikow)
                    {
                        if(uzyt.imie == imieLogin && uzyt.nazwisko == nazwiskoLogin)
                        {
                            Console.WriteLine("Logowanie przebieglo pomyslnie");
                            uzyt.UserInfo();

                            


                        }
                        
                    }

                    break;

                default:
                    Console.WriteLine("Niepoprawana opcja");
                    break;




            }

            

        
           
           
            
        }
    }
}
