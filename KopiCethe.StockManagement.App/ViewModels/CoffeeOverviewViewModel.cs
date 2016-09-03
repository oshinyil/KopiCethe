using KopiCethe.StockManagement.App.Extensions;
using KopiCethe.StockManagement.App.Messages;
using KopiCethe.StockManagement.App.Services;
using KopiCethe.StockManagement.App.Utilities;
using KopiCethe.StockManagement.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace KopiCethe.StockManagement.App.ViewModels
{
    public class CoffeeOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CoffeeDataService coffeeDataService;
        private DialogService dialogService;

        public ICommand EditCommand { get; set; }

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
            dialogService = new DialogService();
            LoadData();
            LoadCommands();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            dialogService.CloseDetailDialog();
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCoffee, CanEditCoffee);
        }

        private bool CanEditCoffee(object obj)
        {
            return (SelectedCoffee != null);
        }

        private void EditCoffee(object obj)
        {
            Messenger.Default.Send<Coffee>(selectedCoffee);
            dialogService.ShowDetailDialog();
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
