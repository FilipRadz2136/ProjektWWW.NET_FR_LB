using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class KontoController : Controller
    {
        private readonly Kantor1DbContext _context;

        public KontoController(Kantor1DbContext context)
        {
            _context = context;
        }

        // GET: Konto/Login
        public IActionResult Login() => View();

        // GET: Konto/Rejestracja
        public IActionResult Rejestracja() => View();

        [HttpPost]
        public async Task<IActionResult> Rejestracja(string email, string haslo)
        {
            if (_context.Uzytkownicy.Any(u => u.Email == email))
            {
                ModelState.AddModelError("", "Email już istnieje");
                return View();
            }

            var user = new Uzytkownik
            {
                Email = email,
                HasloHash = Hashuj(haslo),
                DataRejestracji = DateTime.Now,
                Rola = "User" // Możesz zmienić ręcznie w DB na "Admin"
            };

            _context.Uzytkownicy.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string haslo)
        {
            var hash = Hashuj(haslo);
            var user = _context.Uzytkownicy.FirstOrDefault(u => u.Email == email && u.HasloHash == hash);

            if (user == null)
            {
                ModelState.AddModelError("", "Błędny email lub hasło");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Rola)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Wyloguj()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private string Hashuj(string input)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
