using System;

namespace StockPredictor.Models
{
    public class Stock
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public double CurrentPrice { get; set; }
        public double PE { get; set; }
        public double EPS { get; set; }
        public double ROE { get; set; }
        public double DividendYield { get; set; }
        public double CAGR10Y { get; set; }
        public double VolatilityScore { get; set; }
        public string Sector { get; set; }
        public string Recommendation { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Commentary { get; set; }
        public double[] PastPrices { get; set; }

        public Stock()
        {
            LastUpdated = DateTime.Now;
            PastPrices = Array.Empty<double>();
        }

        public double ProjectedPriceInYears(int years)
        {
            return Math.Round(CurrentPrice * Math.Pow(1 + CAGR10Y, years), 2);
        }

        public void GenerateRecommendation()
        {
            if (CAGR10Y > 0.10 && PE < 30 && ROE > 0.15)
                Recommendation = "Buy";
            else if (CAGR10Y > 0.05)
                Recommendation = "Hold";
            else
                Recommendation = "Sell";
        }
    }
}
