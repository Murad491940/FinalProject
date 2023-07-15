using FinalProject.Common.Enums;
using FinalProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Common.Services
{
    public class ProjectService
    {
        public List<Product> Products;
        public List<Sale> Sales;
        public List<SaleItem> SaleItems;

        public ProjectService()
        {
            Products = new();
            Sales = new();
            SaleItems = new();
        }
        public List<Product> GetProducts()
        {
            return Products;
        }
        public int AddProduct(string name, decimal price, string category, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");
            if (price < 0)
                throw new FormatException("Price is lower o!");
            
            bool isSuccessful
            =Enum.TryParse(typeof(Category), category, true, out object parcedCategory);

            if (!isSuccessful)
            {
                throw new InvalidDataException("Category not found!:");
            }

            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Category= (Category)parcedCategory,
                Quantity= quantity
                    
            };
            Products.Add(newProduct);

            return newProduct.Id;

        }

        public void DeleteProduct(int productId)
        {
            var existingProduct=Products.FirstOrDefault(x=>x.Id == productId);
            if (existingProduct == null)
            {
                throw new Exception($"Product with ID{productId} not found!");

                Products=Products.Where(x=> x.Id == productId).ToList();
            }
        }

        public List<Product> ShowProductsByCategory(Category category)
        {
            var products=Products.Where(x => x.Category == category).ToList();

            return products;
        }

        public List<Product> DisplayProductsByPriceRange(int minimumPrice,int highPrice)
        {
            var products = Products.Where(x => x.Price >=highPrice && x.Price<=minimumPrice).ToList();

            return products;
        }

        public List<Product> SearchProductsByName(string name)
        {
            var products = Products.Where(x => x.Name == name) .ToList();

            return products;
        }

        public static void EditProduct(int Id, string name, int quantity, object category, decimal price)
        {
            // Find the product to update
            var edit = Product.(x => x.Id == Id);
            if (edit == null)
                throw new Exception($"{Id} is invalid");
            if (price < 0)
                throw new FormatException("Price is minium than 0!");
            if (quantity < 0)
                throw new FormatException("Invalid id!");
            edit.ProductName = name;
            edit.ProductPrice = price;
            edit.Quantity = quantity;

        }


    }
}
