# System do zarządzania wypożyczalnią sprzętu komputerowego

[English version below]


Projekt stworzony w ASP.NET MVC jako część studiów. Aplikacja składa się z głównych części:

- **Firma.PortalWWW** – serwis dla klientów (widok publiczny)
- **Firma.Intranet** – panel administracyjny dla pracowników firmy
- **Firma.Data** – warstwa dostępu do bazy danych (Entity Framework Core)

## Technologie

- ASP.NET MVC (.NET 6/7/8)
- Entity Framework Core (Code First)
- SQL Server / LocalDB
- Razor Views (CSHTML)
- Bootstrap 5
- C#
- LINQ

## Struktura projektu

Firma 

 ├── Firma.Data
 
 ├── Firma.Intranet
 
 └── Firma.PortalWWW 

## Funkcjonalności

### Portal (dla klientów)
- Wyświetlanie produktów z podziałem na kategorie
- Filtrowanie po kategorii i przedziale cenowym
- Szczegóły produktu z opiniami
- Dodawanie recenzji (z automatycznym tworzeniem klienta na podstawie e-maila)
- Strona kontaktowa z formularzem i powiązaniem z bazą klientów
- Dane kontaktowe i godziny pracy pobierane dynamicznie z bazy (`UstawieniaPortalu`)
- Obsługa wiadomości (`Wiadomosc`)

### Intranet (dla pracowników)
- CRUD dla:
  - Produktów
  - Rezerwacji
  - Pracowników
  - Kategorii
  - Recenzji
  - Stron CMS
  - Dostaw/Odbiorów
  - Ustawień portalu
- Strona główna z dynamicznymi kafelkami (np. najbliższe rezerwacje, opóźnienia, wiadomości)
- Zegar, skróty i panel użytkownika
- Bezpieczeństwo – przycisk wylogowania

## Uruchomienie lokalne

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/twoj-login/firma.git
2. Otwórz solucję Firma.sln w Visual Studio.
3. Ustaw projekt startowy na Firma.PortalWWW lub Firma.Intranet.
4. Skonfiguruj połączenie do bazy danych w plikach appsettings.json.
5. Wygeneruj bazę danych:
6. ```bash
   dotnet ef database update --project Firma.Data
7. Uruchom aplikację (F5).

## Wymagania

Visual Studio 2022 lub nowszy

Minimum .NET 8 SDK

SQL Server lub LocalDB

Narzędzia EF Core (CLI lub wbudowane w Visual Studio)

## Autor

Projekt studencki – realizowany przez Ernesta Ostap.



# Englissh Version: Computer Equipment Rental Management System

This project was developed in ASP.NET MVC as part of a university course. The application consists of three main components:

- **Firma.PortalWWW** – public-facing portal for customers
- **Firma.Intranet** – internal admin panel for company employees
- **Firma.Data** – data access layer using Entity Framework Core

## Technologies

- ASP.NET MVC (.NET 6/7/8)
- Entity Framework Core (Code First)
- SQL Server / LocalDB
- Razor Views (CSHTML)
- Bootstrap 5
- C#
- LINQ

## Project Structure

Firma 

├── Firma.Data

├── Firma.Intranet

└── Firma.PortalWWW

## Features

### Portal (for customers)
- Display products by category
- Filter products by category and price range
- Product detail pages with customer reviews
- Add reviews (auto-creates customer based on email if not found)
- Contact page with a form and customer integration
- Contact details and business hours loaded dynamically from the database (`UstawieniaPortalu`)
- Contact message handling (`Wiadomosc`)

### Intranet (for employees)
- Full CRUD for:
  - Products
  - Reservations
  - Employees
  - Categories
  - Reviews
  - CMS pages
  - Delivery/Pickup options
  - Portal settings
- Dashboard with dynamic tiles (e.g. upcoming reservations, delays, messages)
- User panel with clock, quick actions, logout button
- Basic access control and security

## Local Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/firma.git
2. Open Firma.sln in Visual Studio.
3. Set the startup project to either Firma.PortalWWW or Firma.Intranet.
4. Configure the database connection in the appsettings.json files.
5. Generate the database:
   ``` bash
   dotnet ef database update --project Firma.Data
6. Run the application (F5).

## Requirements

Visual Studio 2022 or newer

.NET 8 SDK (minimum)

SQL Server or LocalDB

EF Core tools (CLI or integrated in Visual Studio)


## Author

Student project – developed by Ernest Ostap.

---
