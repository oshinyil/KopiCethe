using KopiCethe.StockManagement.Model;
using MahApps.Metro.Controls;
using System.Windows;

namespace KopiCethe.StockManagement.App.Views
{
    /// <summary>
    /// Interaction logic for CoffeeDetailView.xaml
    /// </summary>
    public partial class CoffeeDetailView : MetroWindow
    {
        public Coffee SelectedCoffee { get; set; }

        public CoffeeDetailView()
        {
            InitializeComponent();

            this.Loaded += CoffeeDetailView_Loaded;
        }

        void CoffeeDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = SelectedCoffee;
        }

        private void ChangeCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCoffee.Name = "Something really expensive";
            SelectedCoffee.Price = 10000;

        }

        private void SaveCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
