namespace ProjektWWW.NET_FR_LB.Models
{
    public class AlertKursu
    {
        public int Id { get; set; }

        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        public int WalutaZId { get; set; }
        public Waluta WalutaZ { get; set; }

        public int WalutaDoId { get; set; }
        public Waluta WalutaDo { get; set; }

        public double ProgKursu { get; set; }//Ustawiamy próg poniżej ktorego chcemy wymienić waluty
        public bool PowiadomGdyMniejszy { get; set; }//powiadamia gdy bedzie mniejszy niz ProgKursu

        public bool Aktywny { get; set; }
        public DateTime DataUtworzenia { get; set; }

    }
}
