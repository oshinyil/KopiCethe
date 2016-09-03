using KopiCethe.StockManagement.App.ViewModels;

namespace KopiCethe.StockManagement.App
{
    public class ViewModelLocator
    {
        private static CoffeeOverviewViewModel coffeeOverviewViewModel = new CoffeeOverviewViewModel();
        private static CoffeeDetailViewModel coffeeDetailViewModel = new CoffeeDetailViewModel();

        public static CoffeeDetailViewModel CoffeeDetailViewModel
        {
            get
            {
                return coffeeDetailViewModel;
            }
        }

        public static CoffeeOverviewViewModel CoffeeOverviewViewModel
        {
            get
            {
                return coffeeOverviewViewModel;
            }
        }
    }
}
