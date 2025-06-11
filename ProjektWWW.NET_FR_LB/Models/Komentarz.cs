namespace ProjektWWW.NET_FR_LB.Models
{
    public class Komentarz
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public DateTime DataDodania { get; set; }

        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}
