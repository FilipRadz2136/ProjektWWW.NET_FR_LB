using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjektWWW.NET_FR_LB.Data;
using ProjektWWW.NET_FR_LB.Models;

    public class CurrencyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly Kantor1DbContext _context;

        public CurrencyApiService(HttpClient httpClient, Kantor1DbContext context)
        {
            _httpClient = httpClient;
            _context = context;
            Console.WriteLine("✅ CurrencyApiService z bazą danych ZAŁADOWANY");
        }

        public async Task<Dictionary<string, string>> GetAvailableCurrenciesAsync()
        {
            var waluty = await _context.Waluty.ToListAsync();
            return waluty.ToDictionary(w => w.Kod, w => $"{w.Kraj} {w.Nazwa}");
        }

        public async Task<double?> GetExchangeRateAsync(string fromCurrency, string toCurrency)
        {
            var apiKey = "4f02bb7b6391e0a03691053193985d16";

            var url = $"http://data.fixer.io/api/latest?access_key={apiKey}&symbols={fromCurrency},{toCurrency}";

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"🔄 Kurs {fromCurrency} → {toCurrency}");
            Console.WriteLine(content);

            try
            {
                var json = JsonDocument.Parse(content);

                if (json.RootElement.TryGetProperty("rates", out var rates) &&
                    rates.TryGetProperty(fromCurrency.ToUpper(), out var fromRateElem) &&
                    rates.TryGetProperty(toCurrency.ToUpper(), out var toRateElem))
                {
                    var fromRate = fromRateElem.GetDouble();
                    var toRate = toRateElem.GetDouble();
                    var kurs = toRate / fromRate;

                    Console.WriteLine($"✅ Kurs = {kurs}");
                    return kurs;
                }
                else
                {
                    Console.WriteLine("❌ Brak wymaganych pól w odpowiedzi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Błąd parsowania JSON: " + ex.Message);
            }

            return null;
        }
    }