using System;

namespace StockPredictor.Models
{
    public class Stock
    {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public double CurrentPrice { get; set; }
        public double PE { get; set; }                 // Price-to-Earnings Ratio
        public double EPS { get; set; }                // Earnings Per Share
        public double ROE { get; set; }                // Return on Equity
        public double DividendYield { get; set; }      // %
        public double CAGR10Y { get; set; }            // Compounded Annual Growth Rate over 10 years (%)
        public double VolatilityScore { get; set; }    // Custom score (0–100)
        public string Sector { get; set; }

        // AI or Rule-Based Recommendation: Buy, Hold, Sell
        public string Recommendation { get; set; }

        //
