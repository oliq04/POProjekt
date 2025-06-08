using ProjektRowery;


IDisplay display = new TerminalDisplay();

List<Uzytkownik> listaUzytkownikow = [];
List<StacjaRowerowa> ListaStacji = [
    new(5, "Centrum", "Warszawa", [new(1, Typ.standardowy, "Trek"), new(2, Typ.elektryczny, "Giant") ]),
            new(4, "Dworzec", "Warszawa", [new(3, Typ.standardowy, "Kross"), new(4, Typ.elektryczny, "Specialized") ])
];

void WyswietlWszystkieStacje()
{
    Console.WriteLine("\nLista wszystkich stacji:");
    foreach (var stacja in ListaStacji)
    {
        Console.WriteLine($"{stacja.NazwaStacji}, {stacja.NazwaMiasta} – {stacja.LiczbaWolnychMiejsc} wolnych miejsc");
    }
}

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
            Uzytkownik? zalogowanyUser = listaUzytkownikow.Find(user => user.imie == imie && user.nazwisko == nazwisko);

            if (zalogowanyUser is not null)
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
                            userService.WypiszSaldo(zalogowanyUser);
                            break;
                        case 2:
                            userService.WyswietlHistorie(zalogowanyUser);
                            break;
                        case 3:
                            WyswietlWszystkieStacje();
                            Console.WriteLine("Wybierz numer stacji:");
                            int.TryParse(Console.ReadLine(), out int numerStacji);

                            if (numerStacji >= 1 && numerStacji <= ListaStacji.Count)
                            {
                                StacjaRowerowa wybranaStacja = ListaStacji[numerStacji - 1];

                                wybranaStacja.WyswietlDostepneRowery();
                                Console.WriteLine("Podaj ID roweru, który chcesz wypożyczyć:");
                                int.TryParse(Console.ReadLine(), out int idRoweru);

                                Rower wybranyRower = wybranaStacja.ListaRowerow.FirstOrDefault(rower => rower.id == idRoweru);
                                if (wybranyRower != null && wybranaStacja.czyMoznaWypozyczycRower(wybranyRower))
                                {
                                    rowerService.Wypozycz(wybranyRower, wybranaStacja, zalogowanyUser);
                                    //wybranaStacja.UsunZListyDostepnych(wybranyRower); //tutaj nie jest wogle zmieniany status




                                }
                                else
                                {
                                    Console.WriteLine("Rower nie jest dostępny.");
                                }
                            }
                            break;

                        case 4:
                            
                            userService.WyswietlHistorie(zalogowanyUser);
                            Console.WriteLine("Podaj ID roweru do zwrotu:");
                            int.TryParse(Console.ReadLine(), out int idZwrotu);

                            Wypozyczenie aktywneWypozyczenie = zalogowanyUser.ShowHistory().Find(w => w.rower.id == idZwrotu);

                            if (aktywneWypozyczenie != null)
                            {
                                Rower rower = aktywneWypozyczenie.rower;
                                WyswietlWszystkieStacje();
                                Console.WriteLine("Wybierz numer stacji do zwrotu:");
                                int.TryParse(Console.ReadLine(), out int numerStacjiZwrot);

                                if (numerStacjiZwrot >= 1 && numerStacjiZwrot <= ListaStacji.Count)
                                {
                                    StacjaRowerowa stacjaZwrotu = ListaStacji[numerStacjiZwrot - 1];

                                    rowerService.zwrocRower(rower, stacjaZwrotu, zalogowanyUser);

                                   
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
            WyswietlWszystkieStacje();
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
