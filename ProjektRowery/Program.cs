using System.ComponentModel.Design;
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

            new StacjaRowerowa(5, "Centrum", "Warszawa", new List<Rower> { new Rower(1, Typ.standardowy, "Trek"), new Rower(2, Typ.elektryczny, "Giant") });
            new StacjaRowerowa(4, "Dworzec", "Warszawa", new List<Rower> { new Rower(3, Typ.standardowy, "Kross"), new Rower(4, Typ.elektryczny, "Specialized") });

            bool aplikacjaAktywna = true;

            while (aplikacjaAktywna)
            {
                Console.WriteLine("\nWitaj w aplikacji wypożyczalni miejskiej rowerów!");
                Console.WriteLine("Aby wypożyczyć rower, zaloguj się na swoje konto lub utwórz nowe!\n");

                Console.WriteLine("1. Utwórz nowe konto");
                Console.WriteLine("2. Zaloguj się");
                Console.WriteLine("3. Wyświetl dostępne stacje rowerowe");
                Console.WriteLine("4. Zakończ działanie programu");

                int.TryParse(Console.ReadLine(), out int wybor);

                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("Podaj imię:");
                        string imie = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko:");
                        string nazwisko = Console.ReadLine();

                        try
                        {
                            Uzytkownik user = new Uzytkownik(imie, nazwisko);
                            listaUzytkownikow.Add(user);
                            Console.WriteLine("Pomyślnie utworzono użytkownika.");
                        }
                        catch
                        {
                            Console.WriteLine("Błąd przy tworzeniu konta.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Podaj imię:");
                        string imieLogin = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko:");
                        string nazwiskoLogin = Console.ReadLine();

                        Uzytkownik zalogowanyUser = listaUzytkownikow.Find(user => user.imie == imieLogin && user.nazwisko == nazwiskoLogin);

                        if (zalogowanyUser != null)
                        {
                            Console.WriteLine($"Logowanie przebiegło pomyślnie. Witaj, {zalogowanyUser.imie}!");

                            bool aktywneMenu = true;
                            while (aktywneMenu)
                            {
                                Console.WriteLine("\nCo chcesz zrobić?");
                                Console.WriteLine("1. Wyświetlić saldo");
                                Console.WriteLine("2. Wyświetlić historię wypożyczeń");
                                Console.WriteLine("3. Wypożyczyć rower");
                                Console.WriteLine("4. Zwrócić rower");
                                Console.WriteLine("5. Zgłosić usterkę roweru");
                                Console.WriteLine("6. Wyloguj się");

                                int.TryParse(Console.ReadLine(), out int wyborAkcji);

                                switch (wyborAkcji)
                                {
                                    case 1:
                                        zalogowanyUser.WypiszSaldo();
                                        break;
                                    case 2:
                                        zalogowanyUser.WyswietlHistorie();
                                        break;
                                    case 3:
                                        StacjaRowerowa.WyswietlWszystkieStacje();
                                        Console.WriteLine("Wybierz numer stacji:");
                                        int.TryParse(Console.ReadLine(), out int numerStacji);

                                        if (numerStacji >= 1 && numerStacji <= StacjaRowerowa.ListaStacji.Count)
                                        {
                                            StacjaRowerowa wybranaStacja = StacjaRowerowa.ListaStacji[numerStacji - 1];

                                            wybranaStacja.WyswietlDostepneRowery();
                                            Console.WriteLine("Podaj ID roweru, który chcesz wypożyczyć:");
                                            int.TryParse(Console.ReadLine(), out int idRoweru);

                                            Rower wybranyRower = wybranaStacja.ListaRowerow.FirstOrDefault(rower => rower.id == idRoweru);
                                            if (wybranyRower != null && wybranaStacja.czyMoznaWypozyczycRower(wybranyRower))
                                            {
                                                zalogowanyUser.WypozyczRower(wybranaStacja,wybranyRower);
                                                //wybranaStacja.UsunZListyDostepnych(wybranyRower); //tutaj nie jest wogle zmieniany status
                                                
                                                

                                                
                                            }
                                            else
                                            {
                                                Console.WriteLine("Rower nie jest dostępny.");
                                            }
                                        }
                                        break;
                                    case 4:
                                        //Tu trzeba wyswietlic wypozyczone rowery przez uzytkownika, zeby latwiej bylo zwrocic
                                        zalogowanyUser.WyswietlHistorie();
                                        Console.WriteLine("Podaj ID roweru do zwrotu:");
                                        int.TryParse(Console.ReadLine(), out int idZwrotu);

                                        Wypozyczenie aktywneWypozyczenie = zalogowanyUser.historiaWypozyczen.Find(wypozyczenie => wypozyczenie.rower.id == idZwrotu && wypozyczenie.czasZwrotu == null);

                                        if (aktywneWypozyczenie != null)
                                        {
                                            StacjaRowerowa.WyswietlWszystkieStacje();
                                            Console.WriteLine("Wybierz numer stacji do zwrotu:");
                                            int.TryParse(Console.ReadLine(), out int numerStacjiZwrot);

                                            if (numerStacjiZwrot >= 1 && numerStacjiZwrot <= StacjaRowerowa.ListaStacji.Count)
                                            {
                                                StacjaRowerowa stacjaZwrotu = StacjaRowerowa.ListaStacji[numerStacjiZwrot - 1];

                                                aktywneWypozyczenie.rower.zwrocRower();
                                                aktywneWypozyczenie.ZakonczWypozyczenie();
                                                stacjaZwrotu.DodajDoListyDostepnych(aktywneWypozyczenie.rower);

                                                
                                            }
                                        }
                                        break;
                                    case 5:
                                        Console.WriteLine("Tutaj dodamy funkcję.");
                                        break;
                                    case 6:
                                        aktywneMenu = false;
                                        Console.WriteLine("Wylogowano.");
                                        break;
                                    default:
                                        Console.WriteLine("Niepoprawna opcja.");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono użytkownika. Sprawdź poprawność danych.");
                        }
                        break;

                    case 3:
                        StacjaRowerowa.WyswietlWszystkieStacje();
                        break;

                    case 4:
                        aplikacjaAktywna = false;
                        Console.WriteLine("Zakończono działanie programu.");
                        break;

                    default:
                        Console.WriteLine("Niepoprawna opcja.");
                        break;
                }
            }
        }
    }
}
