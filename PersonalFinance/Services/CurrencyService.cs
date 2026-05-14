using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Data;
using PersonalFinance.Models;

namespace PersonalFinance.Services
{
    public class CurrencyService
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _http;

        public CurrencyService(AppDbContext context, HttpClient http)
        {
            _context = context;
            _http = http;
        }

        public async Task<decimal> GetRateForDate(string currencyCode, DateTime date)
        {
            if (currencyCode == "PLN") return 1m;

            return await GetLatestAvailableRate(currencyCode, date);
        }

        public async Task<decimal> GetLatestAvailableRate(string currencyCode, DateTime date)
        {
            if (currencyCode == "PLN") return 1m;

            for (int i = 0; i < 7; i++)
            {
                DateTime checkDate = date.AddDays(-i);
                string formattedDate = checkDate.ToString("yyyy-MM-dd");

                var rateInDb = await _context.CurrencyRates
                    .FirstOrDefaultAsync(r => r.Code == currencyCode && r.LastUpdated.Date == checkDate.Date);

                if (rateInDb != null) return rateInDb.Rate;

                try
                {
                    var nbpRate = await _http.GetFromJsonAsync<NbpSingleRate>(
                        $"https://api.nbp.pl/api/exchangerates/rates/A/{currencyCode}/{formattedDate}/?format=json");

                    if (nbpRate?.Rates != null && nbpRate.Rates.Any())
                    {
                        decimal midRate = nbpRate.Rates[0].Mid;

                        _context.CurrencyRates.Add(new CurrencyRate
                        {
                            Code = currencyCode,
                            Rate = midRate,
                            LastUpdated = DateTime.SpecifyKind(checkDate.Date, DateTimeKind.Utc)
                        });
                        await _context.SaveChangesAsync();

                        return midRate;
                    }
                }
                catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    continue;
                }
                catch (Exception)
                {
                    break;
                }
            }

            var lastAnyRate = await _context.CurrencyRates
                .Where(r => r.Code == currencyCode)
                .OrderByDescending(r => r.LastUpdated)
                .FirstOrDefaultAsync();

            return lastAnyRate?.Rate ?? 1m;
        }
        private class NbpSingleRate { public List<NbpRateDetails> Rates { get; set; } }
        private class NbpRateDetails { public decimal Mid { get; set; } }
    }
}
