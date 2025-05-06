namespace ProjektWWW.NET_FR_LB.Models
{
    public class KursWaluty
    {
        public int Id { get; set; }

        public int WalutaZId { get; set; }
        public Waluta WalutaZ { get; set; }

        public int WalutaDoId { get; set; }
        public Waluta WalutaDo { get; set; }

        public int ZrodloId { get; set; }
        public ZrodloKursu Zrodlo { get; set; }

        public double Kurs { get; set; }
        public DateTime Data { get; set; }

    }
}
