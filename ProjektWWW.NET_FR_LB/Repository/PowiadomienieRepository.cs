using System.Collections.Generic;
using System.Linq;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;

public class PowiadomienieRepository : IPowiadomienieRepository
{
    private readonly Kantor1DbContext _db;
    public PowiadomienieRepository(Kantor1DbContext db)
    {
        _db = db;
    }

    public IEnumerable<Powiadomienie> PobierzDlaUzytkownika(int uzytkownikId)
        => _db.Powiadomienia.Where(p => p.UzytkownikId == uzytkownikId).ToList();

    public Powiadomienie Pobierz(int id)
        => _db.Powiadomienia.FirstOrDefault(p => p.Id == id);

    public void Dodaj(Powiadomienie powiadomienie)
    {
        _db.Powiadomienia.Add(powiadomienie);
        _db.SaveChanges();
    }

    public void OznaczJakoPrzeczytane(int id)
    {
        var powiadomienie = _db.Powiadomienia.Find(id);
        if (powiadomienie != null)
        {
            powiadomienie.Przeczytane = true;
            _db.SaveChanges();
        }
    }

    public void Usun(int id)
    {
        var powiadomienie = _db.Powiadomienia.Find(id);
        if (powiadomienie != null)
        {
            _db.Powiadomienia.Remove(powiadomienie);
            _db.SaveChanges();
        }
    }
}