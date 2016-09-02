using KopiCethe.StockManagement.Model;
using System.Collections.Generic;

namespace KopiCethe.StockManagement.DataAccess
{
    public interface ICoffeeRepository
    {
        Coffee GetACoffee();
        Coffee GetCoffeeById(int id);
        List<Coffee> GetCoffees();
        void UpdateCoffee(Coffee coffee);
        void DeleteCoffee(Coffee coffee);
    }
}
