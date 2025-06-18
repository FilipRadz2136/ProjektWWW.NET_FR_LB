using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Kantor1DbContext _context;

        public HomeController(ILogger<HomeController> logger, Kantor1DbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var waluty = await _context.Waluty.ToListAsync();
            return View(waluty);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SzukajWaluty(string q)
        {
            var waluty = _context.Waluty
                .Where(w => w.Kod.Contains(q) || w.Nazwa.Contains(q))
                .Select(w => new { w.Kod, w.Nazwa, w.Kraj })
                .Take(10)
                .ToList();
            return Json(waluty);
        }
        public IActionResult NowyWidok()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
