using ProjektRowery;
using System.Diagnostics;

List<Uzytkownik> listaUzytkownikow = [];
List<StacjaRowerowa> ListaStacji = [
    new(1, 5, "Centrum", "Warszawa", [new(1, Typ.standardowy, "Trek"), new(2, Typ.elektryczny, "Giant") ]),
    new(2, 4, "Dworzec", "Warszawa", [new(3, Typ.standardowy, "Kross"), new(4, Typ.elektryczny, "Specialized") ])
];



Uzytkownik Tomasz = new Uzytkownik("Tomasz", "Problem");
listaUzytkownikow.Add(Tomasz);


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
            string imie = GetName("imię");
            string nazwisko = GetName("nazwisko");

            try
            {
                listaUzytkownikow.Add(new(imie, nazwisko));
                Console.WriteLine("Pomyślnie utworzono użytkownika.");
            }
            catch
            {
                Console.WriteLine("Błąd przy tworzeniu konta.");
            }
            break;

        case 2:
            imie = GetName("imię");
            nazwisko = GetName("nazwisko");
            RowerService rowerService = new RowerService();
            UzytkownikService userService = new UzytkownikService();
            Uzytkownik? zalogowanyUser = listaUzytkownikow.Find(user => user.GetImie() == imie && user.GetImie() == nazwisko);

            if (zalogowanyUser is not null)
            {
                Console.WriteLine($"Logowanie przebiegło pomyślnie. Witaj, {zalogowanyUser.GetImie}!");

                bool aktywneMenu = true;
                while (aktywneMenu)
                {
                    Console.WriteLine("\nCo chcesz zrobić?");
                    Console.WriteLine("1. Wyświetlić saldo");
                    Console.WriteLine("2. Dodać środki do salda");
                    Console.WriteLine("3. Wyświetlić historię wypożyczeń");
                    Console.WriteLine("4. Wypożyczyć rower");
                    Console.WriteLine("5. Zwrócić rower");
                    Console.WriteLine("6. Wyloguj się");

                    int.TryParse(Console.ReadLine(), out int wyborAkcji);

                    switch (wyborAkcji)
                    {
                        case 1:
                            userService.WypiszSaldo(zalogowanyUser);
                            break;
                        case 2:
                            double kwota;
                            bool success = false;
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Write("Podaj kwotę do dodania do salda: ");
                                string? input = Console.ReadLine();
                                if (double.TryParse(input, out kwota) && kwota>0)
                                {
                                    userService.DodajSaldo(zalogowanyUser, kwota);
                                    success = true;
                                    break;
                                }
                                else
                                {Console.WriteLine("To nie jest poprawna liczba. Spróbuj ponownie.");}
                            }
                            if (!success)
                            {Console.WriteLine("Przekroczono liczbę prób. Nie dodano nic do salda.");}
                            break;
                        case 3:
                            userService.WyswietlHistorie(zalogowanyUser);
                            break;
                        case 4:
                            double saldo = userService.ZwrocSaldo(zalogowanyUser);
                            if (saldo < 60)
                            {
                                userService.WypiszSaldo(zalogowanyUser);
                                Console.WriteLine("Nie masz wystarczającego salda, aby wypożyczyć rower. Minimalne saldo to 60 zł.");
                                break;
                            }
                            StacjaRowerowa.WyswietlWszystkieStacje(ListaStacji);
                            Console.WriteLine("Wybierz numer stacji:");
                            int.TryParse(Console.ReadLine(), out int numerStacji);

                            if (numerStacji >= 1 && numerStacji <= ListaStacji.Count)
                            {
                                StacjaRowerowa wybranaStacja = ListaStacji[numerStacji - 1];

                                wybranaStacja.WyswietlDostepneRowery();
                                Console.WriteLine("Podaj ID roweru, który chcesz wypożyczyć:");
                                int.TryParse(Console.ReadLine(), out int idRoweru);

                                Rower wybranyRower = wybranaStacja.ListaRowerow.FirstOrDefault(rower => rower.id == idRoweru);
                                if (wybranyRower != null && wybranaStacja.czyMoznaWypozyczycRower(wybranyRower) )
                                {
                                    rowerService.Wypozycz(wybranyRower, wybranaStacja, zalogowanyUser, userService);
                                }
                                else
                                {
                                    Console.WriteLine("Rower nie jest dostępny.");
                                }
                            }
                            break;

                        case 5:
                            userService.WyswietlHistorie(zalogowanyUser);
                            Console.WriteLine("Podaj ID roweru do zwrotu:");
                            int.TryParse(Console.ReadLine(), out int idZwrotu);
                            Wypozyczenie aktywneWypozyczenie =zalogowanyUser.ShowHistory().Find(w => w.rower.id == idZwrotu);

                            if (aktywneWypozyczenie != null)
                            {
                                Rower rower = aktywneWypozyczenie.rower;
                                StacjaRowerowa.WyswietlWszystkieStacje(ListaStacji);
                                Console.WriteLine("Wybierz numer stacji do zwrotu:");
                                int.TryParse(Console.ReadLine(), out int numerStacjiZwrot);

                                if (numerStacjiZwrot >= 1 && numerStacjiZwrot <= ListaStacji.Count)
                                {
                                    Console.WriteLine("Czy doszło do jakiejś usterki T/N");
                                    bool oczekujOdp = true;
                                    while (oczekujOdp)
                                    {
                                        char odp = Console.ReadKey().KeyChar;
                                        var stacjaZwrotu = ListaStacji[numerStacjiZwrot - 1];

                                        if (odp == 'T' || odp == 't')
                                        {
                                            aktywneWypozyczenie.ZakonczWypozyczenie();
                                            rowerService.zwrocRower(rower, stacjaZwrotu, zalogowanyUser);
                                            rowerService.ZglosUsterke(rower);
                                            oczekujOdp = false;
                                            Console.WriteLine("\nUsterka zgłoszona. Rower zostanie przekazany do serwisu.");
                                        }
                                        else if (odp == 'N' || odp == 'n')
                                        {
                                            aktywneWypozyczenie.ZakonczWypozyczenie();
                                            rowerService.zwrocRower(rower, stacjaZwrotu, zalogowanyUser);
                                            oczekujOdp = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nNiepoprawna odpowiedź. Wpisz T lub N.");
                                        }
                                    }

                                    int czasWMinutach = aktywneWypozyczenie.ObliczCzas();
                                    Console.WriteLine($"Czas wypożyczenia: {czasWMinutach} minut");

                                    var platnoscService = new Platnosc();

                                    string typRoweru = rowerService.ZwrocTypEnum(aktywneWypozyczenie.rower).ToString();

                                    double zaplata = platnoscService.ObliczKwote(typRoweru, czasWMinutach);
                                    Console.WriteLine($"Do zapłaty: {zaplata} zł");
                                    userService.Oplac(zalogowanyUser, zaplata);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nie znaleziono aktywnego wypożyczenia o podanym ID.");
                            }
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
            StacjaRowerowa.WyswietlWszystkieStacje(ListaStacji);
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
static string GetName(string displayName)
{
    string value = "A";
    do
        Console.WriteLine(string.IsNullOrWhiteSpace(value)
            ? $"Podaj prawidlowe {displayName}:"
            : $"Podaj {displayName}:");
    while (string.IsNullOrWhiteSpace(value = Console.ReadLine() ?? string.Empty));
    return value;
}
