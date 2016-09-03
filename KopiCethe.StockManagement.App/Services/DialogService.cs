using KopiCethe.StockManagement.App.Views;
using System.Windows;

namespace KopiCethe.StockManagement.App.Services
{
    public class DialogService
    {

        Window coffeeDetailView = null;

        public DialogService()
        {
        }

        public void ShowDetailDialog()
        {
            coffeeDetailView = new CoffeeDetailView();
            coffeeDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            if (coffeeDetailView != null)
            {
                coffeeDetailView.Close();
            }
        }
    }
}
