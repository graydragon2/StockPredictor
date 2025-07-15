using System;
using StockPredictor.Models;

namespace StockPredictor.Services
{
    public class PredictionEngine
    {
        public void Evaluate(Stock stock)
        {
            if (stock == null) return;

            if (stock.CAGR10Y >= 0.10 && stock.PE < 30 && stock.ROE > 0.15)
            {
                stock.Recommendation = "Buy";
                stock.Commentary = "Strong growth and healthy fundamentals.";
            }
            else if (stock.CAGR10Y >= 0.05)
            {
                stock.Recommendation = "Hold";
                stock.Commentary = "Moderate long-term growth potential.";
            }
            else
            {
                stock.Recommendation = "Sell";
                stock.Commentary = "Low growth or weak fundamentals.";
            }
        }

        public double EstimateFuturePrice(Stock stock, int years)
        {
            if (stock == null || stock.CurrentPrice <= 0 || stock.CAGR10Y <= 0)
                return 0;

            return Math.Round(stock.CurrentPrice * Math.Pow(1 + stock.CAGR10Y, years), 2);
        }

        public void EstimateVolatility(Stock stock)
        {
            if (stock?.PastPrices == null || stock.PastPrices.Length < 2)
            {
                stock.VolatilityScore = 0;
                return;
            }

            double mean = 0;
            foreach (var price in stock.PastPrices)
                mean += price;
            mean /= stock.PastPrices.Length;

            double variance = 0;
            foreach (var price in stock.PastPrices)
                variance += Math.Pow(price - mean, 2);
            variance /= stock.PastPrices.Length;

            double stdDev = Math.Sqrt(variance);

            stock.VolatilityScore = Math.Round(Math.Min(100, stdDev / mean * 100), 2);
        }
    }
}
