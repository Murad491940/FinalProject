using ConsoleApp30.Base;
using ConsoleApp30.Enums;
using ConsoleApp30.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30.Services
{
    public class MarketService : IMarketService
    {
        public List<Product> Products { get; set; } = new List<Product>
        {
            new Product()
            {
                Category = Category.TV,
                Count = 10,
                Name = "Sony",
                Price = 1200.0m
            },
            new Product()
            {
                Category = Category.MOBIL,
                Count = 10,
                Name = "Iphone 14",
                Price = 2450.99m
            },
            new Product()
            {
                Category = Category.NOTEBOOK,
                Count = 10,
                Name = "HP",
                Price = 2500.95m
            }
        };
        public List<Sale> Sales { get; set; } = new List<Sale>();
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

        public MarketService()
        {

        }

        public List<Product> GetProducts()
        {
            return this.Products;
        }

        /// <summary>
        /// Adding new products
        /// </summary>
        public int AddProduct(string name, decimal price, string category, int count)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("The name does not exist!");

            if (price <= 0)
                throw new FormatException("Value cannot be negative!");

            if (string.IsNullOrWhiteSpace(category))
                throw new FormatException("It does not belong to this category!");

            if (count < 0)
                throw new FormatException("Number cannot be negative!");


            bool isSuccessful
                = Enum.TryParse(typeof(Category), category, true, out object parsedCategory);

            if (!isSuccessful)
            {
                throw new InvalidDataException("The category was not entered correctly!");
            }

            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Category = (Category)parsedCategory,
                Count = count,
            };

            Products.Add(newProduct);
            return newProduct.Id;
        }

        /// <summary>
        /// Deleting existing products
        /// </summary>
        public void DeleteProduct(int Id)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == Id);

            if (currentProduct is not null)
            {
                Products.Remove(currentProduct);
            }
            else
            {
                //custom not found exception
            }
        }

        /// <summary>
        /// Cheking product quantity have or not have
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool CheckProductQuantity(int productId, int quantity)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == productId);

            if (currentProduct is not null)
            {
                return currentProduct.Count > quantity;
            }
            else
            {
                //return custom exception - NotInStockException
                return false;
            }
        }

        /// <summary>
        /// Decreasing product quantity for sale
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void DecreaseProductQuantity(int productId, int quantity)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == productId);

            if (currentProduct is not null)
            {
                currentProduct.Count -= quantity;
            }
            else
            {
                //return custom exception - NotInStockException
            }
        }

        /// <summary>
        /// Increasing product quantity for sale
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void IncreaseProductQuantity(int productId, int quantity)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == productId);

            if (currentProduct is not null)
            {
                currentProduct.Count += quantity;
            }
            else
            {
                //return custom exception - NotInStockException
            }
        }

        /// <summary>
        /// Showing product according to its category
        /// </summary>
        /// <param name="selectedCategory"></param>
        /// <returns></returns>
        public List<Product> ShowProductsByCategory(Category selectedCategory)
        {
            var data = Products.Where(x => x.Category == selectedCategory).ToList();
            return data;
        }

        /// <summary>
        /// Showing product according to its price
        /// </summary>
        /// <param name="lowest"></param>
        /// <param name="highest"></param>
        /// <returns></returns>
        public List<Product> DisplayProductsByPriceRange(int MinimumPrice, int HighPrice)
        {
            var data = Products.Where(x => x.Price >= MinimumPrice && x.Price <= HighPrice).ToList();
            return data;
        }

        /// <summary>
        /// Showing product according to its name
        /// </summary>
        /// <param name="inputname"></param>
        /// <returns></returns>
        public List<Product> SearchProductsByName(string name)
        {
            var data = Products.Where(x => x.Name == name).ToList();
            return data;
        }

        /// <summary>
        /// This metod editing products properties
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <param name="category"></param>
        /// <param name="price"></param>
        public void EditProduct(int Id, string name, int count, object category, decimal price)
        {
            // Find the product to update
            var update = Products.FirstOrDefault(x => x.Id == Id);
            if (update == null)
                throw new Exception($"{Id} is invalid");
            if (price < 0)
                throw new FormatException("Value cannot be negative");
            if (count < 0)
                throw new FormatException("Not found!");
            update.Name = name;
            update.Price = price;
            update.Count = count;
            update.Category = (Category)category;

        }

        /// <summary>
        /// That metod adding new sales
        /// </summary>
        /// <param name="sale"></param>
        /// <exception cref="Exception"></exception>
        public void AddSale(Sale sale)
        {
            foreach (var saleItem in sale.SaleItems)
            {
                var tmp = CheckProductQuantity(saleItem.Product.Id, saleItem.Count);
                if (!tmp)
                {
                    //new custom exception - NotEnoughInStcokException
                    throw new Exception($"Out of {saleItem.Count} {saleItem.Product.Name} in Stock");
                }
            }

            Sales.Add(sale);

            foreach (var saleItem in sale.SaleItems)
            {
                DecreaseProductQuantity(saleItem.Product.Id, saleItem.Count);
            }

        }

    }
}
