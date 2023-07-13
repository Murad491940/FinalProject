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

        private Sale[] _sales; 
        public Sale[] Products { get { return _sales; } }

        public void AddSale(string salenumber, decimal price, SaleItem sale, string saletime)
        {
            foreach (Sale item in _sales)
            {
                if (item.SaleNumber==salenumber)
                {
                    return;
                }
            }
            Sale _sale=new Sale(salenumber,price,sale,saletime);
            Array.Resize(ref _sales,_sales.Length-1);
            _sales[_sales.Length - 1] = _sale;


        }



        public void AddProduct(string name, string surname, ProductCategory category, string productCount, string productId)
        {
           
        }

       

        public void EditProduct(string name, string surname, ProductCategory category, string productCount)
        {
           
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
