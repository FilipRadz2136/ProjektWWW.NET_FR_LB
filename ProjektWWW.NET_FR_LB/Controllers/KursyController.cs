using Microsoft.AspNetCore.Mvc;
using ProjektWWW.NET_FR_LB.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;

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
        private async Task<(List<string> labels, List<decimal> values)> PobierzHistorieKursuNBP(string kodWaluty, int dni = 30)
        {
            using var http = new HttpClient();
            var url = $"https://api.nbp.pl/api/exchangerates/rates/A/{kodWaluty}/last/{dni}/?format=json";
            var response = await http.GetAsync(url);
            if (!response.IsSuccessStatusCode) return (new List<string>(), new List<decimal>());
            var json = await response.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject(json);

            var labels = new List<string>();
            var values = new List<decimal>();
            foreach (var rate in data.rates)
            {
                labels.Add((string)rate.effectiveDate);
                values.Add((decimal)rate.mid);
            }
            return (labels, values);
        }
        public IActionResult Wykres(string kodWaluty = "EUR")
        {
            ViewBag.KodWaluty = kodWaluty;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> HistoriaKursowWszystkich([FromQuery] int dni = 30)
        {
            var waluty = _db.Waluty.Select(w => w.Kod).ToList();
            var datasets = new List<object>();

            foreach (var kod in waluty)
            {
                if (kod == "PLN") continue;

                var (labels, values) = await PobierzHistorieKursuNBP(kod, dni);
                datasets.Add(new
                {
                    label = $"Kurs {kod}",
                    data = values,
                    borderColor = "#" + Guid.NewGuid().ToString("N").Substring(0, 6),
                    fill = false
                });
            }

            var sampleLabels = await PobierzHistorieKursuNBP(waluty.FirstOrDefault(w => w != "PLN"), dni);
            return Json(new { labels = sampleLabels.labels, datasets });
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