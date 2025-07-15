using System;

namespace StockPredictor.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public double AmountInvested { get; set; }
        public double PricePerShare { get; set; }
        public DateTime PurchaseDate { get; set; }

        public double SharesPurchased
        {
            get
            {
                if (PricePerShare <= 0) return 0;
                return Math.Round(AmountInvested / PricePerShare, 6);
            }
        }

        public string Notes { get; set; }

        public Investment()
        {
            PurchaseDate = DateTime.Now;
        }
    }
}
