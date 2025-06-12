using System.Collections.Generic;
using ProjektWWW.NET_FR_LB.Models;

public interface IPowiadomienieRepository
{
    IEnumerable<Powiadomienie> PobierzDlaUzytkownika(int uzytkownikId);
    Powiadomienie Pobierz(int id);
    void Dodaj(Powiadomienie powiadomienie);
    void OznaczJakoPrzeczytane(int id);
    void Usun(int id);
}