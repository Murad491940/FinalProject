using ConsoleApp30.Enums;
using ConsoleApp30.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30.Base
{
    public interface IMarketService
    {
        int AddProduct(string name, decimal price, string category, int count);
        void DeleteProduct(int Id);
        bool CheckProductQuantity(int productId, int quantity);
        void DecreaseProductQuantity(int productId, int quantity);
        void IncreaseProductQuantity(int productId, int quantity);
        List<Product> ShowProductsByCategory(Category Category);
        List<Product> DisplayProductsByPriceRange(int MinimumPrice, int HighPrice);
        List<Product> SearchProductsByName(string name);
        void EditProduct(int Id, string name, int count, object category, decimal price);
        void AddSale(Sale sale);
    }
}
