using KopiCethe.StockManagement.App.Extensions;
using KopiCethe.StockManagement.App.Services;
using KopiCethe.StockManagement.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace KopiCethe.StockManagement.App.ViewModels
{
    public class CoffeeOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoffeeDataService coffeeDataService;

        private ObservableCollection<Coffee> coffees;
        public ObservableCollection<Coffee> Coffees
        {
            get
            {
                return coffees;
            }
            set
            {
                coffees = value;
                RaisePropertyChanged("Coffees");
            }
        }

        private Coffee selectedCoffee;

        public Coffee SelectedCoffee
        {
            get
            {
                return selectedCoffee;
            }
            set
            {
                selectedCoffee = value;
                RaisePropertyChanged("SelectedCoffee");
            }
        }

        public CoffeeOverviewViewModel()
        {
            coffeeDataService = new CoffeeDataService();
            LoadData();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void LoadData()
        {
            Coffees = coffeeDataService.GetAllCoffees().ToObservableCollection();
        }
    }
}
