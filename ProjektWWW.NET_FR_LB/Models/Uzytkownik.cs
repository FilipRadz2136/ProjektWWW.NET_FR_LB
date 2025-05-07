namespace ProjektWWW.NET_FR_LB.Models
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HasloHash { get; set; }
        public DateTime DataRejestracji { get; set; }

        public ICollection<UzytkownikRola> UzytkownikRolas { get; set; }
    }
}
    