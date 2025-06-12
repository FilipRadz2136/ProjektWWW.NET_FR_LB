namespace ProjektWWW.NET_FR_LB.Models
{
    public class Powiadomienie
    {
        public int Id { get; set; }
        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
        public string Tresc { get; set; }
        public DateTime DataDodania { get; set; }
        public bool Przeczytane { get; set; }
    }
}