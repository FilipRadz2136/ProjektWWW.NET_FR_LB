using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjektWWW.NET_FR_LB.Models;

namespace ProjektWWW.NET_FR_LB.Data
{
    public class Kantor1DbContext : DbContext
    {
        public Kantor1DbContext(DbContextOptions<Kantor1DbContext> options)
            : base(options)
        {
        }

        public DbSet<Waluta> Waluty { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<UlubioneKursiki> UlubioneKursiki { get; set; }
        public DbSet<HistoriaWymianUzytkownika> HistoriaWymianUzytkownika { get; set; }
        public DbSet<AlertKursu> AlertyKursow { get; set; }
        public DbSet<Akcje> Akcje { get; set; }
        public DbSet<Rola> Rola { get; set; }
        public DbSet<Komentarz> Komentarze { get; set; }
        public DbSet<UzytkownikRola> UzytkownikRole { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Waluta>().HasData(
    new Waluta { Id = 100, Kod = "USD", Nazwa = "Dolar amerykański", Symbol = "$", Kraj = "🇺🇸" },
    new Waluta { Id = 101, Kod = "EUR", Nazwa = "Euro", Symbol = "€", Kraj = "🇪🇺" },
    new Waluta { Id = 102, Kod = "GBP", Nazwa = "Funt brytyjski", Symbol = "£", Kraj = "🇬🇧" },
    new Waluta { Id = 103, Kod = "PLN", Nazwa = "Złoty polski", Symbol = "zł", Kraj = "🇵🇱" },
    new Waluta { Id = 104, Kod = "JPY", Nazwa = "Jen japoński", Symbol = "¥", Kraj = "🇯🇵" },
    new Waluta { Id = 105, Kod = "CHF", Nazwa = "Frank szwajcarski", Symbol = "CHF", Kraj = "🇨🇭" },
    new Waluta { Id = 106, Kod = "AUD", Nazwa = "Dolar australijski", Symbol = "A$", Kraj = "🇦🇺" },
    new Waluta { Id = 107, Kod = "CAD", Nazwa = "Dolar kanadyjski", Symbol = "C$", Kraj = "🇨🇦" },
    new Waluta { Id = 108, Kod = "NOK", Nazwa = "Korona norweska", Symbol = "kr", Kraj = "🇳🇴" },
    new Waluta { Id = 110, Kod = "SEK", Nazwa = "Korona szwedzka", Symbol = "kr", Kraj = "🇸🇪" },
    new Waluta { Id = 111, Kod = "CNY", Nazwa = "Juan chiński", Symbol = "¥", Kraj = "🇨🇳" },
    new Waluta { Id = 112, Kod = "NZD", Nazwa = "Dolar nowozelandzki", Symbol = "NZ$", Kraj = "🇳🇿" },
    new Waluta { Id = 113, Kod = "CZK", Nazwa = "Korona czeska", Symbol = "Kč", Kraj = "🇨🇿" },
    new Waluta { Id = 114, Kod = "DKK", Nazwa = "Korona duńska", Symbol = "kr", Kraj = "🇩🇰" },
    new Waluta { Id = 115, Kod = "HUF", Nazwa = "Forint węgierski", Symbol = "Ft", Kraj = "🇭🇺" },
    new Waluta { Id = 116, Kod = "ZAR", Nazwa = "Rand południowoafrykański", Symbol = "R", Kraj = "🇿🇦" },
    new Waluta { Id = 117, Kod = "ILS", Nazwa = "Nowy izraelski szekel", Symbol = "₪", Kraj = "🇮🇱" },
    new Waluta { Id = 118, Kod = "MXN", Nazwa = "Peso meksykańskie", Symbol = "$", Kraj = "🇲🇽" },
    new Waluta { Id = 119, Kod = "TRY", Nazwa = "Lira turecka", Symbol = "₺", Kraj = "🇹🇷" },
    new Waluta { Id = 120, Kod = "SGD", Nazwa = "Dolar singapurski", Symbol = "S$", Kraj = "🇸🇬" }
);

            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<UzytkownikRola>()
                    .HasKey(ur => new { ur.UzytkownikId, ur.RolaId });

                modelBuilder.Entity<UzytkownikRola>()
                    .HasOne(ur => ur.Uzytkownik)
                    .WithMany(u => u.UzytkownikRole)
                    .HasForeignKey(ur => ur.UzytkownikId);

                modelBuilder.Entity<UzytkownikRola>()
                    .HasOne(ur => ur.Rola)
                    .WithMany(r => r.UzytkownikRole)
                    .HasForeignKey(ur => ur.RolaId);
            }
        }
    }
}