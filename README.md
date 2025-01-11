# EShop - Aplikacja e-commerce

## Spis treści
- [Wprowadzenie](#wprowadzenie)
- [Architektura projektu](#architektura-projektu)
- [Wykorzystane technologie](#wykorzystane-technologie)
- [Funkcjonalności](#funkcjonalności)
- [Konfiguracja środowiska](#konfiguracja-środowiska)
- [Konta użytkowników](#konta-użytkowników)
- [Instrukcja użytkownika](#instrukcja-użytkownika)
- [Panel administratora](#panel-administratora)
- [System autoryzacji](#system-autoryzacji)

## Wprowadzenie

EShop to nowoczesna aplikacja e-commerce zbudowana w oparciu o technologię .NET 9. Projekt został zaprojektowany z myślą o skalowalności, łatwej rozbudowie oraz przyjaznym interfejsie użytkownika. Aplikacja oferuje kompleksowe rozwiązanie dla sklepów internetowych, włączając w to zarządzanie produktami, obsługę koszyka zakupowego oraz zaawansowany system autoryzacji.

## Architektura projektu

Projekt został podzielony na trzy główne warstwy, zgodnie z zasadami Clean Architecture:

- **EShop.Core** - Warstwa zawierająca logikę biznesową, modele domenowe oraz interfejsy repozytoriów
- **EShop.Infrastructure** - Warstwa odpowiedzialna za implementację dostępu do danych, konfigurację usług oraz integrację z zewnętrznymi systemami
- **EShop.Web** - Warstwa prezentacji zawierająca kontrolery, widoki oraz modele widoków

## Wykorzystane technologie

- **.NET 9** - Najnowsza wersja platformy .NET oferująca wysoką wydajność i nowoczesne funkcje programistyczne
- **Entity Framework Core** - Framework ORM umożliwiający mapowanie obiektowo-relacyjne i pracę z bazą danych
- **ASP.NET Core Identity** - Kompleksowe rozwiązanie do zarządzania użytkownikami i rolami
- **Bootstrap 5** - Framework CSS zapewniający responsywny i nowoczesny interfejs użytkownika
- **SQL Server** - Wydajny system zarządzania bazą danych

## Funkcjonalności

### System użytkowników
- Rejestracja nowych użytkowników
- Logowanie do systemu
- Zarządzanie profilem użytkownika
- System ról i uprawnień

### Katalog produktów
- Przeglądanie listy produktów
- Szczegółowe karty produktów
- Filtrowanie i wyszukiwanie
- Kategoryzacja produktów

### Koszyk zakupowy
- Dodawanie produktów do koszyka
- Modyfikacja ilości produktów
- Usuwanie produktów
- Podgląd sumy zamówienia

## Konfiguracja środowiska

### Wymagania systemowe
- .NET 9 SDK
- SQL Server (2019 lub nowszy)
- Visual Studio 2022 lub nowsze (zalecane)

### Konfiguracja bazy danych
1. Konfiguracja połączenia znajduje się w pliku `appsettings.json`
2. Baza danych jest tworzona automatycznie przy pierwszym uruchomieniu dzięki migracjom Entity Framework
3. Początkowe dane są wprowadzane przez system seed

### Struktura plików
- Pliki CSS: `wwwroot/css/`
- Komponenty Bootstrap: zintegrowane przez CDN
- Skrypty: `wwwroot/js/`

## Konta użytkowników

### Konto testowe użytkownika
- Login: jan.kowalski.@example.mail
- Hasło: zaq1@WSX
- Uprawnienia: podstawowe funkcje użytkownika

### Konto administratora
- Login: admin
- Hasło: administrator
- Uprawnienia: pełny dostęp do systemu

## Instrukcja użytkownika

### Rejestracja i logowanie
1. Wybierz opcję "Zarejestruj się" na stronie głównej
2. Wypełnij formularz rejestracyjny
3. Zaloguj się używając utworzonych danych

### Przeglądanie produktów
- Produkty są wyświetlane w formie kafli na stronie głównej
- Możliwość filtrowania po kategoriach, nazwie i cenie

### Obsługa koszyka
- Dodawanie produktów przez przycisk "Dodaj do koszyka"
- Modyfikacja ilości w widoku koszyka
- Usuwanie produktów z koszyka

### Zarządzanie kontem
- Edycja danych osobowych
- Zmiana hasła

## Panel administratora

### Zarządzanie produktami i katalogami
- Dodawanie nowych produktów
- Edycja istniejących produktów
- Usuwanie produktów
- Zarządzanie kategoriami

## System autoryzacji

### Poziomy dostępu
1. **Gość** - przeglądanie produktów
2. **Użytkownik** - koszyk, zarządzanie kontem
3. **Administrator** - pełny dostęp do systemu

### Zabezpieczenia
- Hasła szyfrowane zgodnie ze standardami bezpieczeństwa
- Walidacja danych wejściowych (po stronie klienta i serwera)
