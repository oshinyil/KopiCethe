using KopiCethe.StockManagement.App.Services;
using KopiCethe.StockManagement.Model;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KopiCethe.StockManagement.App.Views
{
    /// <summary>
    /// Interaction logic for CoffeeOverviewView.xaml
    /// </summary>
    public partial class CoffeeOverviewView : MetroWindow
    {
        private Coffee selectedCoffee;
        private List<Coffee> coffees;

        public CoffeeOverviewView()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            var coffeeDataService = new CoffeeDataService();
            coffees = coffeeDataService.GetAllCoffees();
            CoffeeListView.ItemsSource = coffees;
        }

        private void EditCoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            CoffeeDetailView coffeeDetailView = new CoffeeDetailView();
            coffeeDetailView.SelectedCoffee = selectedCoffee;
            coffeeDetailView.ShowDialog();
        }

        private void CoffeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCoffee = e.AddedItems[0] as Coffee;

            if (e != null)
            {
                CoffeeIdLabel.Content = selectedCoffee.Id;
                CoffeeNameLabel.Content = selectedCoffee.Name;
                DescriptionLabel.Content = selectedCoffee.Description;
                PriceLabel.Content = selectedCoffee.Price;
                StockAmountLabel.Content = selectedCoffee.AmountInStock.ToString();
                FirstTimeAddedLabel.Content = selectedCoffee.FirstAddedToStockDate.ToShortDateString();

                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri("/KopiCethe.StockManagement.App;component/Images/coffee" + selectedCoffee.Id + ".jpg", UriKind.Relative);
                img.EndInit();
                CoffeeImage.Source = img;
            }
        }

        private void AddFakeCoffeeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
