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
        public DbSet<KursWaluty> KursyWalut { get; set; }
        public DbSet<ZrodloKursu> ZrodlaKursow { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<UlubioneKursiki> UlubioneKursiki { get; set; }
        public DbSet<HistoriaWymianUzytkownika> HistoriaWymianUzytkownika { get; set; }
        public DbSet<AlertKursu> AlertyKursow { get; set; }
        public DbSet<Akcje> Akcje { get; set; }
        public DbSet<HistoriaAktualizacji> HistorieAktualizacji { get; set; }
    }
}