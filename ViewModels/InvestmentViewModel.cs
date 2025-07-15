using System;
using System.Collections.ObjectModel;
using StockPredictor.Models;

namespace StockPredictor.ViewModels
{
    public class InvestmentViewModel : BaseViewModel
    {
        private string _ticker;
        public string Ticker
        {
            get => _ticker;
            set => SetProperty(ref _ticker, value);
        }

        private double _amount;
        public double Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        private double _price;
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public DateTime Date { get; set; } = DateTime.Now;

        public ObservableCollection<Investment> Investments { get; set; }

        public InvestmentViewModel()
        {
            Investments = new ObservableCollection<Investment>();
        }

        public void AddInvestment()
        {
            var investment = new Investment
            {
                Ticker = Ticker,
                AmountInvested = Amount,
                PricePerShare = Price,
                PurchaseDate = Date
            };

            Investments.Add(investment);
            ClearInputs();
        }

        private void ClearInputs()
        {
            Ticker = string.Empty;
            Amount = 0;
            Price = 0;
            Date = DateTime.Now;
        }
    }
}
