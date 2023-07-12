using FinalProject.Enums;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    interface IMarketable
    {
        public Sale[] Sales { get; set; }

        void AddSale(string salenumber, decimal price, SaleItem sale, DateTime dateTime);
        Product[] GetProduct();
        Sale[] GetAllProducts();
        Sale[] Time(DateTime saletime);
        Sale[] Price(decimal price);
        Sale[] SaleNumber(string salenumber);
        void AddProduct(string name, string surname, ProductCategory category, string productCount, string productId);
        void EditProduct(string name, string surname, ProductCategory category, string productCount);
        Sale[] ProductCatewgory(ProductCategory category);
        Product[] ProductPrice(decimal price);
        Product[] ProductSearch(string name);












    }
}
