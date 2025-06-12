using Microsoft.AspNetCore.Mvc;
using ProjektWWW.NET_FR_LB.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWWW.NET_FR_LB.Controllers
{
    public class KursyController : Controller
    {
        private readonly Kantor1DbContext _db;
        private readonly CurrencyApiService _currencyService;

        public KursyController(Kantor1DbContext db, CurrencyApiService currencyService)
        {
            _db = db;
            _currencyService = currencyService;
        }
        public IActionResult AktualnyKurs(string from, string to, decimal? amount)
        {
            var waluty = _db.Waluty.OrderBy(w => w.Nazwa).ToList();
            ViewBag.Waluty = waluty;
            ViewBag.From = from;
            ViewBag.To = to;
            ViewBag.Amount = amount;

            decimal? kurs = null;
            string blad = null;

            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to) && amount.HasValue)
            {
                try
                {
                    kurs = (decimal?)_currencyService.GetExchangeRateAsync(from, to).GetAwaiter().GetResult();
                }
                catch
                {
                    blad = "Nie udało się pobrać kursu.";
                }
            }

            if (kurs != null)
            {
                ViewBag.Kurs = kurs.Value;
                ViewBag.Blad = null;
            }
            else
            {
                ViewBag.Kurs = null;
                ViewBag.Blad = blad;
            }

            return View();
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