﻿using FinalProject.Enums;
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
        public Sale[] Sales { get;}

        void AddSale(string salenumber, decimal price, SaleItem sale, string saletime);
        Product[] GetProduct();
        Sale[] GetAllProducts();
        Sale[] Time(string saletime);
        Sale[] Price(decimal price);
        Sale[] SaleNumber(string salenumber);
        void AddProduct(string name, string surname, ProductCategory category, string productCount, string productId);
        void EditProduct(string name, string surname, ProductCategory category, string productCount);
        Sale[] ProductCategory(ProductCategory category);
        Product[] ProductPrice(decimal price);
        Product[] ProductSearch(string name);












    }
}