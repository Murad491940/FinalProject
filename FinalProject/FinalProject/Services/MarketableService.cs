using FinalProject.Enums;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    class MarketableService : IMarketable
    {
        public Sale[] Sales { get; set; }

        public void AddProduct(string name, string surname, ProductCategory category, string productCount, string productId)
        {
            throw new NotImplementedException();
        }

        public void AddSale(string salenumber, decimal price, SaleItem sale, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(string name, string surname, ProductCategory category, string productCount)
        {
            throw new NotImplementedException();
        }

        public Sale[] GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product[] GetProduct()
        {
            throw new NotImplementedException();
        }

        public Sale[] Price(decimal price)
        {
            throw new NotImplementedException();
        }

        public Sale[] ProductCatewgory(ProductCategory category)
        {
            throw new NotImplementedException();
        }

        public Product[] ProductPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Product[] ProductSearch(string name)
        {
            throw new NotImplementedException();
        }

        public Sale[] SaleNumber(string salenumber)
        {
            throw new NotImplementedException();
        }

        public Sale[] Time(DateTime saletime)
        {
            throw new NotImplementedException();
        }
    }
}
