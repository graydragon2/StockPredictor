using System;

namespace StockPredictor.Models
{
    public class Investment
    {
        public int Id { get; set; }                        // Unique ID (for database)
        public string Ticker { get; set; }                 // e.g., "AAPL"
        public double AmountInvested { get; set; }         // Total dollars invested in this entry
        public double PricePerShare { get; set; }          // Price at the time of purchase
        public DateTime PurchaseDate { get; set; }         // Date of investment

        // Computed property
        public double SharesPurchased
        {
            get
            {
                if (PricePerShare <= 0) return 0;
                return Math.Round(AmountInvested / PricePerShare, 6);
            }
        }

        public string Notes { get; set; }                  // Optional notes (e.g., "Dip buy", "Dividend reinvest")

        public Investment()
        {
            PurchaseDate = DateTime.Now;
        }
    }
}