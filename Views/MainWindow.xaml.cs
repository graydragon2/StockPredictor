using System.Windows;
using StockPredictor.ViewModels;

namespace StockPredictor.Views
{
    public partial class MainWindow : Window
    {
        private InvestmentViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = DataContext as InvestmentViewModel;
        }

        private void AddInvestment_Click(object sender, RoutedEventArgs e)
        {
            _vm?.AddInvestment();
        }
    }
}
