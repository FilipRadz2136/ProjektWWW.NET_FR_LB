using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using System.Linq;
using System.Security.Claims;

[Authorize]
public class AlertyController : Controller
{
    private readonly Kantor1DbContext _db;

    public AlertyController(Kantor1DbContext db)
    {
        _db = db;
    }

    // Lista alertów zalogowanego użytkownika
    public IActionResult Lista()
    {
        // Pobierz id zalogowanego użytkownika (przykład, dostosuj do swojego systemu logowania)
        int userId = GetLoggedUserId();
        var alerty = _db.AlertyKursow
            .Where(a => a.UzytkownikId == userId)
            .ToList();
        return View(alerty);
    }

    // GET: Dodaj alert
    public IActionResult Dodaj()
    {
        ViewBag.Waluty = new SelectList(_db.Waluty.OrderBy(w => w.Nazwa), "Id", "Nazwa");
        return View();
    }

    // POST: Dodaj alert
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Dodaj(AlertKursu alert)
    {
        if (ModelState.IsValid)
        {
            alert.Aktywny = true;
            alert.DataUtworzenia = DateTime.Now;
            alert.UzytkownikId = GetLoggedUserId(); // Ustaw id zalogowanego użytkownika!
            _db.AlertyKursow.Add(alert);
            _db.SaveChanges();
            return RedirectToAction("Lista");
        }
        ViewBag.Waluty = new SelectList(_db.Waluty.OrderBy(w => w.Nazwa), "Id", "Nazwa");
        return View(alert);
    }

    // Pomocnicza metoda do pobierania id użytkownika (dostosuj do swojego systemu logowania)
    private int GetLoggedUserId()
    {
        // Jeśli id użytkownika jest int
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim == null)
            throw new Exception("Brak claimu z id użytkownika!");
        return int.Parse(claim.Value);
    }
}