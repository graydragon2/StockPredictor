using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockPredictor.Models;

namespace StockPredictor.Services
{
    public class StockApiService
    {
        private readonly HttpClient _httpClient;

        public StockApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Stock> FetchStockInfoAsync(string ticker)
        {
            try
            {
                string url = $"https://query1.finance.yahoo.com/v7/finance/quote?symbols={ticker}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(json);
                var result = data["quoteResponse"]?["result"]?[0];

                if (result == null)
                    return null;

                return new Stock
                {
                    Ticker = result.Value<string>("symbol") ?? ticker,
                    CompanyName = result.Value<string>("shortName") ?? "N/A",
                    CurrentPrice = result.Value<double?>("regularMarketPrice") ?? 0,
                    PE = result.Value<double?>("trailingPE") ?? 0,
                    EPS = result.Value<double?>("epsTrailingTwelveMonths") ?? 0,
                    ROE = 0, // Placeholder; Yahoo API doesn't include this
                    DividendYield = (result.Value<double?>("dividendYield") ?? 0) * 100,
                    Sector = result.Value<string>("sector") ?? "Unknown",
                    LastUpdated = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch stock data: {ex.Message}");
                return null;
            }
        }
    }
}