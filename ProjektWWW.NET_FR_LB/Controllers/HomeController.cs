using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Kantor1DbContext _context;

        // Konstruktor kontrolera
        public HomeController(ILogger<HomeController> logger, Kantor1DbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //pobieramy wszystkie waluty z bazy danych
            var waluty = await _context.Waluty.ToListAsync();

            return View(waluty);
        }

        public IActionResult Privacy()
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
