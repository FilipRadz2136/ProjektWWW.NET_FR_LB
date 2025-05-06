namespace ProjektWWW.NET_FR_LB.Models
{
    public class HistoriaAktualizacji
    {
        public int Id { get; set; }

        public int ZrodloId { get; set; }
        public ZrodloKursu Zrodlo { get; set; }

        public DateTime DataAktualizacji { get; set; }
        public int LiczbaPobranychKursow { get; set; }
    }
}
