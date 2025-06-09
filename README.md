Dokumentacja systemu wypożyczalni rowerów
------------------------------
Spis treści
------------------------------
1. Opis systemu
2. Instrukcja uruchomienia
3. Instrukcja użytkownika


==============================
Opis systemu
==============================
System zarządzania rowerami na stacjach rowerowych to aplikacja konsolowa w języku C#, która pozwala na:
-rejestrację użytkownika
-logowanie użytkownika
-sprawdzanie dostępności stacji z rowerami
-wyświetlanie stanu konta
-dodawanie środków do konta
-wyświetlanie historii wypożyczonych i wypożyczanych rowerów
-wypożyczanie rowerów z stacji
-zwracania rowerów
-zgłaszania usterek
-wyświetlania cen usług


==============================
Instrukcja uruchomienia
==============================
1. Wejdź w folder /bin/Debug/net8.0/
2. Otwórz plik ProjektRowerowy.exe

==============================
Instrukcja obsługi
==============================
Główne menu
==============================
Po uruchomieniu programu wyświetla się menu główne z następującymi opcjami:
1. Utwórz nowe konto
2. Zaloguj się
3. Wyświetl dostępne stacje rowerowe
4. Zakończ działanie programu


==============================
Podstawowe operacje (menu główne)
==============================to:
-wybierz opcję 1 i naciśnij Enter,
-wprowadź imię oraz nazwisko,
-jeżeli dane są poprawne pojawi się komunikat „Pomyślnie utworzono użytkownika”.

Zaloguj się:
-wybierz opcję 2 i naciśnij Enter,
-wprowadź imię oraz nazwisko,
-jeżeli dane są poprawne nastąpi logowanie, w przeciwnym razie pojawi się komunikat o błędzie.

Wyświetl dostępne stacje rowerowe:
-wybierz opcję 3 i naciśnij Enter,
-wyświetli się lista stacji wraz z numerem, lokalizacją i dostępnymi rowerami.

Zakończ działanie programu:
-wybierz opcję 4 i naciśnij Enter,
-program zakończy działanie.


==============================
Menu użytkownika (po zalogowaniu)
==============================
Po zalogowaniu się pojawia się menu użytkownika:
1. Wyświetlić saldo
2. Dodać środki do salda
3. Wyświetlić historię wypożyczeń
4. Wypożyczyć rower
5. Zwrócić rower
6. Cennik
7. Wyloguj się

Wyświetlić saldo:
-wybierz opcję 1 i naciśnij Enter,
-wyświetli się aktualne saldo konta.

Dodać środki do salda:
-wybierz opcję 2 i naciśnij Enter,
-wprowadź kwotę większą od 0,
-po zatwierdzeniu saldo zostanie zwiększone, a program wyświetli potwierdzenie.

Wyświetlić historię wypożyczeń:
-wybierz opcję 3 i naciśnij Enter,
-zostanie wyświetlona lista wszystkich wypożyczeń wraz z datami, czasem i ID rowerów.

Wypożyczyć rower:
-upewnij się, że saldo wynosi co najmniej 60 zł,
-wybierz opcję 4 i naciśnij Enter,
-program pokaże wszystkie stacje; wpisz numer stacji,
-zostanie wyświetlona lista rowerów; wpisz ID wybranego roweru,
-jeśli rower jest dostępny, wypożyczenie zostanie zarejestrowane, a saldo zablokowane.

Zwrócić rower:
-wybierz opcję 5 i naciśnij Enter,
-program pokaże aktywne wypożyczenia; wpisz ID roweru do zwrotu,
-wpisz numer stacji, do której zwracasz rower,
-określ, czy rower ma usterkę (T/N),
-program obliczy czas wypożyczenia, naliczy opłatę i zaktualizuje saldo.

Cennik:
-wybierz opcję 6 i naciśnij Enter,
-wyświetli się aktualny cennik:
  * rower standardowy – pierwsze 30 min 10 zł, każda kolejna minuta 0,50 zł
  * rower elektryczny – pierwsze 30 min 20 zł, każda kolejna minuta 1 zł
  * minimalne saldo do wypożyczenia – 60 zł

Wyloguj się:
-wybierz opcję 7 i naciśnij Enter,
-powrót do menu głównego.

