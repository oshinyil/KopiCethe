using KopiCethe.StockManagement.App.Messages;
using KopiCethe.StockManagement.App.Services;
using KopiCethe.StockManagement.App.Utilities;
using KopiCethe.StockManagement.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace KopiCethe.StockManagement.App.ViewModels
{
    public class CoffeeDetailViewModel : INotifyPropertyChanged
    {
        private CoffeeDataService coffeeDataService;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

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

        public CoffeeDetailViewModel()
        {
            coffeeDataService = new CoffeeDataService();
            SaveCommand = new CustomCommand(SaveCoffee, CanSaveCoffee);
            DeleteCommand = new CustomCommand(DeleteCoffee, CanDeleteCoffee);

            Messenger.Default.Register<Coffee>(this, OnCoffeeReceived);
        }

        private void OnCoffeeReceived(Coffee coffee)
        {
            SelectedCoffee = coffee;
        }

        private bool CanDeleteCoffee(object obj)
        {
            return true;
        }

        private void DeleteCoffee(object coffee)
        {
            coffeeDataService.DeleteCoffee(selectedCoffee);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanSaveCoffee(object obj)
        {
            return true;
        }

        private void SaveCoffee(object coffee)
        {
            coffeeDataService.UpdateCoffee(selectedCoffee);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
