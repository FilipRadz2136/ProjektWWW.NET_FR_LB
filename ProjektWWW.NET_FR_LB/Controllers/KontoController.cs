using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class KontoController : Controller
    {
        private readonly Kantor1DbContext _context;

        public KontoController(Kantor1DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string haslo)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(haslo))
            {
                ViewBag.Error = "Email i hasło są wymagane.";
                return View();
            }

            var user = await _context.Uzytkownicy
                .Include(u => u.UzytkownikRole)
                    .ThenInclude(ur => ur.Rola)
                .FirstOrDefaultAsync(u => u.Email == email && u.HasloHash == Hash(haslo));

            if (user == null)
            {
                ViewBag.Error = "Nieprawidłowy login lub hasło.";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            foreach (var rola in user.UzytkownikRole)
            {
                claims.Add(new Claim(ClaimTypes.Role, rola.Rola.NazwaRoli));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string haslo)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(haslo))
            {
                ViewBag.Error = "Email i hasło są wymagane.";
                return View();
            }

            if (await _context.Uzytkownicy.AnyAsync(u => u.Email == email))
            {
                ViewBag.Error = "Użytkownik o podanym emailu już istnieje.";
                return View();
            }

            var user = new Uzytkownik
            {
                Email = email,
                HasloHash = Hash(haslo),
                DataRejestracji = DateTime.Now
            };

            _context.Uzytkownicy.Add(user);
            await _context.SaveChangesAsync();

            // domyslna rola - uzytkownik (mamy juz admina w bazie danych)
            var rolaUzytkownik = await _context.Rola.FirstOrDefaultAsync(r => r.NazwaRoli == "Uzytkownik");
            if (rolaUzytkownik != null)
            {
                _context.UzytkownikRole.Add(new UzytkownikRola
                {
                    UzytkownikId = user.Id,
                    RolaId = rolaUzytkownik.Id
                });
                await _context.SaveChangesAsync();
            }

            // automatyczne logowanie
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Uzytkownik")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Konto");
        }

        //narazie zwykly hash moze pozniej bedzie inny
        private string Hash(string input)
        {
            return input.GetHashCode().ToString();
        }
    }
}
