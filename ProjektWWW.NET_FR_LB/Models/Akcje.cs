namespace ProjektWWW.NET_FR_LB.Models
{
    public class Akcje
    {
        public int Id { get; set; }
        public string Akcja { get; set; }//Ulubiona Para, Logowanie itp
        public string Szczegoly { get; set; }//Jaka ulubiona para, jaki uzytkownik sie zalogowal
        public DateTime Data { get; set; }

        public int? UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}
