using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    [Authorize]
    public class KomentarzeController : Controller
    {
        private readonly Kantor1DbContext _context;

        public KomentarzeController(Kantor1DbContext context)
        {
            _context = context;
        }

        // POST: /Komentarze/Dodaj
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Dodaj(Komentarz komentarz)
        {
            if (string.IsNullOrWhiteSpace(komentarz.Tresc))
            {
                ModelState.AddModelError("", "Treść komentarza nie może być pusta.");
                return RedirectToAction("AktualnyKurs", "Kursy");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            komentarz.UzytkownikId = int.Parse(userId);
            komentarz.DataDodania = DateTime.Now;

            _context.Komentarze.Add(komentarz);
            await _context.SaveChangesAsync();

            return RedirectToAction("AktualnyKurs", "Kursy");
        }

        // GET: /Komentarze/Lista
        [AllowAnonymous]
        public async Task<IActionResult> Lista()
        {
            var komentarze = await _context.Komentarze
                .Include(k => k.Uzytkownik)
                .OrderByDescending(k => k.DataDodania)
                .ToListAsync();

            return View(komentarze); // lub PartialView("_ListaKomentarzy", komentarze)
        }

        // (opcjonalnie) GET: /Komentarze/Index dla moderatora
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Index()
        {
            var komentarze = await _context.Komentarze
                .Include(k => k.Uzytkownik)
                .ToListAsync();

            return View(komentarze);
        }
    }
}
