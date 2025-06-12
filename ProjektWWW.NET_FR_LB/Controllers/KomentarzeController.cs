using Microsoft.AspNetCore.Mvc;
using ProjektWWW.NET_FR_LB.Models;
using ProjektWWW.NET_FR_LB.Data;
using System.Threading.Tasks;
using System.Linq;


public class KomentarzeController : Controller
{
    private readonly Kantor1DbContext _context;
    private readonly IPowiadomienieRepository _powiadomienieRepo;
    public KomentarzeController(Kantor1DbContext context, IPowiadomienieRepository powiadomienieRepo)
    {
        _context = context;
        _powiadomienieRepo = powiadomienieRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Dodaj(string tresc, IFormFile plik)
    {
        if (string.IsNullOrWhiteSpace(tresc))
            return RedirectToAction("Index", "Home");

        string nazwaPliku = null;
        if (plik != null && plik.Length > 0)
        {
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            nazwaPliku = Guid.NewGuid().ToString() + Path.GetExtension(plik.FileName);
            var filePath = Path.Combine(uploads, nazwaPliku);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await plik.CopyToAsync(stream);
            }
        }

        var komentarz = new Komentarz
        {
            Tresc = tresc,
            DataDodania = DateTime.Now,
            Uzytkownik = User.Identity.IsAuthenticated ? User.Identity.Name : "Anonim",
            NazwaPliku = nazwaPliku
        };

        _context.Komentarze.Add(komentarz);
        await _context.SaveChangesAsync();
        if (User.Identity.IsAuthenticated)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
            _powiadomienieRepo.Dodaj(new Powiadomienie
            {
                UzytkownikId = userId,
                Tresc = "Twój komentarz został dodany!",
                DataDodania = DateTime.Now,
                Przeczytane = false
            });
        }
        return RedirectToAction("Lista");
    }

    public IActionResult Lista()
    {
        var komentarze = _context.Komentarze.OrderByDescending(k => k.DataDodania).ToList();
        return View(komentarze);
    }
    [HttpPost]
    public IActionResult Usun(int id)
    {
        var komentarz = _context.Komentarze.FirstOrDefault(k => k.Id == id);
        if (komentarz != null)
        {
                    if (!string.IsNullOrEmpty(komentarz.Uzytkownik) && komentarz.Uzytkownik != "Anonim")
        {
            // Znajdź użytkownika po nazwie (UserName)
            var uzytkownik = _context.Uzytkownicy.FirstOrDefault(u => u.Email == komentarz.Uzytkownik);
            if (uzytkownik != null)
            {
                _powiadomienieRepo.Dodaj(new Powiadomienie
                {
                    UzytkownikId = uzytkownik.Id,
                    Tresc = "Twój komentarz został usunięty przez moderatora.",
                    DataDodania = DateTime.Now,
                    Przeczytane = false
                });
            }
        }
            _context.Komentarze.Remove(komentarz);
            _context.SaveChanges();
        }
        return RedirectToAction("Lista");
    }
}