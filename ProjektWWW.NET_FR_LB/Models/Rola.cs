namespace ProjektWWW.NET_FR_LB.Models
{
    public class Rola
    {
        public int Id {  get; set; }
        public string NazwaRoli { get; set; }
        public ICollection<UzytkownikRola> UzytkownikRolas { get; set; }
    }
}
