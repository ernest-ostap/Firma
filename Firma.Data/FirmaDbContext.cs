using Firma.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data
{
    public class FirmaDbContext : DbContext
    {
        public FirmaDbContext(DbContextOptions<FirmaDbContext> options) : base(options) { }

        public DbSet<Produkt> Produkty => Set<Produkt>();
        public DbSet<Kategoria> Kategorie => Set<Kategoria>();
        public DbSet<Rezerwacja> Rezerwacje => Set<Rezerwacja>();
        public DbSet<Pracownik> Pracownicy => Set<Pracownik>();
        public DbSet<Recenzja> Recenzje => Set<Recenzja>();
        public DbSet<StronaCMS> StronyCMS => Set<StronaCMS>();
        public DbSet<Dostawa> Dostawy => Set<Dostawa>();
        public DbSet<UstawieniaPortalu> UstawieniaPortalu => Set<UstawieniaPortalu>();
        public DbSet<Klient> Klienci => Set<Klient>();
        public DbSet<Faktura> Faktury => Set<Faktura>();
        public DbSet<Wiadomosc> Wiadomosci => Set<Wiadomosc>();
    }
}
