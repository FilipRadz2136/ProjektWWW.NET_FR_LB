using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjektWWW.NET_FR_LB.Models;
using ProjektWWW.NET_FR_LB.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWalutaRepository _walutaRepository;

        public HomeController(ILogger<HomeController> logger, IWalutaRepository walutaRepository)
        {
            _logger = logger;
            _walutaRepository = walutaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var waluty = await _walutaRepository.GetAllAsync();
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
