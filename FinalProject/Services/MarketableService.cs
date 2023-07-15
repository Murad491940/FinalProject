using FinalProject.Enums;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalProject.Services
{
    class MarketableService : IMarketable
    {
        public MarketableService()
        {
            _sales=new Sale[0];
        }

        private Sale[] _sales; 
        public Sale[] Products { get { return _sales; } }

        public Sale[] Sales => throw new NotImplementedException();

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
            if (productId == productId) ;

        }

       

        public void EditProduct(string productId,string newproductId)
        {
          
            
        }

        public Sale[] GetAllProducts()
        {
            Sale[] products = new Sale[0];
            foreach (Sale product in _sales)
            {
                foreach (var pr in Sales)
                {
                    Array.Resize(ref products, products.Length - 1);
                    products[products.Length-1] = pr;
                }
                return products;
            }
        }

        public Product[] GetProduct()
        {
            throw new NotImplementedException();
        }

        public Sale[] Price(decimal price)
        {
            throw new NotImplementedException();
        }

        public Sale[] ProductCategory(ProductCategory category)
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

        public Sale[] Time(string saletime)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(string name, string surname, ProductCategory category, string productCount)
        {
            throw new NotImplementedException();
        }
    }
}
