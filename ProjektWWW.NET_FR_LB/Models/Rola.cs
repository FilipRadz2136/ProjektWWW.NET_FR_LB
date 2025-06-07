namespace ProjektWWW.NET_FR_LB.Models
{
    public class Rola
    {
        public int Id { get; set; }
        public string NazwaRoli { get; set; }

        public ICollection<UzytkownikRola> UzytkownikRole { get; set; } = new List<UzytkownikRola>();
    }

    public class UzytkownikRola
    {
        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        public int RolaId { get; set; }
        public Rola Rola { get; set; }
    }
}
