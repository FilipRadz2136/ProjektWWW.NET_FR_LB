using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class KursyController : Controller
    {
        private readonly CurrencyApiService _currencyService;

        public KursyController(CurrencyApiService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<IActionResult> DostepneWaluty()
        {
            var waluty = await _currencyService.GetAvailableCurrenciesAsync();
            return View(waluty);
        }

        public async Task<IActionResult> AktualnyKurs(string from = "USD", string to = "PLN")
        {
            var kurs = await _currencyService.GetExchangeRateAsync(from, to);

            ViewBag.From = from;
            ViewBag.To = to;

            if (kurs != null)
            {
                ViewBag.Kurs = kurs.Value.ToString("F4");
                ViewBag.Blad = null;
            }
            else
            {
                ViewBag.Kurs = null;
                ViewBag.Blad = "Nie udało się pobrać kursu.";
            }

            return View();
        }

        [HttpGet]
        [Route("api/waluty")]
        public async Task<IActionResult> GetWaluty()
        {
            var waluty = await _currencyService.GetAvailableCurrenciesAsync();

            if (waluty == null)
            {
                Console.WriteLine("🔴 GetWaluty(): waluty == null");
                return StatusCode(500, "Błąd podczas pobierania walut.");
            }

            Console.WriteLine("🟢 GetWaluty(): pobrano " + waluty.Count + " walut");

            return Ok(waluty);
        }

        [HttpGet]
        [Route("api/kurs")]
        public async Task<IActionResult> GetKurs([FromQuery] string from, [FromQuery] string to)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                return BadRequest("Podaj oba kody walut (from, to).");

            var kurs = await _currencyService.GetExchangeRateAsync(from.ToUpper(), to.ToUpper());

            if (kurs == null)
                return StatusCode(500, "Nie udało się pobrać kursu.");

            return Ok(new { From = from, To = to, Kurs = kurs.Value });
        }
    }
}
