namespace ProjektWWW.NET_FR_LB.Models
{
    public class UzytkownikRola
    {
        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }  

        public int RolaId {  get; set; }
        public Rola Rola { get; set; } 

    }
}
