using FinalProject.Common.Enums;
using FinalProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace FinalProject.Common.Services
{
    public class MenuService
    {
        private static ProjectService projectService = new();
        #region Product
        public static void MenuProduct()
        {
            try
            {
                var products = projectService.GetProducts();

                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Quantity");


                if (products.Count == 0)
                {
                    Console.WriteLine("No product's yet.");
                    return;
                }
                foreach ( var item in products )
                {
                    table.AddRow(item.Id, item.Name, item.Price, item.Category, item.Quantity);
                }
                table.Write();
                
            }
            catch (Exception ex)
            {

                Console.WriteLine("Oops!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter product price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter product category:");
                string category = Console.ReadLine();

                Console.WriteLine("Enter product count:");
                int quantity = int.Parse(Console.ReadLine());

                int productId = projectService.AddProduct(name, price, category, quantity);

                Console.WriteLine($"Added product with ID:{productId}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDelateProduct()
        {
            try
            {
                Console.WriteLine("Enter product's ID:");
                int productId=int.Parse(Console.ReadLine());
                projectService.DeleteProduct(productId);
                Console.WriteLine($"Successfully deleted doctor with ID:{productId}");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Oops");
                Console.WriteLine(ex.Message);
            }  
        }
        public static void ShowProductsByCategory()
        {
            try
            {
                Console.WriteLine("Enter Category:");
                foreach(Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine(category);
                }

                string EnterCategory=Console.ReadLine();
                if (Enum.TryParse<Category>(EnterCategory, out Category eCategory))
                {
                    Console.WriteLine($"Enter Category: {EnterCategory}");
                    var products = projectService.ShowProductsByCategory(eCategory);
                    var table = new ConsoleTable("Name", "Price", "Category", "Count", "Id");

                    if (products.Count == 0)
                    {
                        Console.WriteLine("No product");
                        return;
                    }
                    foreach (Product item in products)
                    {
                        table.AddRow(item.Price, item.Price, item.Category, item.Quantity, item.Id);
                    }
                    table.Write();
                }
                else { Console.WriteLine("You have entered the wrong category!"); }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops");
                Console.WriteLine(ex.Message);
            }
        }
        public static void DisplayProductsByPriceRange()
        {
            try 
            {
                Console.WriteLine("Enter a high price: ");
               
                int HighPrice=int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the minimum price: ");

                int MinimumPrice=int.Parse(Console.ReadLine()); 

                if (MinimumPrice<0 && HighPrice<0)
                {
                    throw new Exception("The price cannot be neganive!: ");
                }
                var products = projectService.DisplayProductsByPriceRange(HighPrice, MinimumPrice);
                var table = (new ConsoleTable("Name", "Price", "Category", "Quantity", "Id"));
                if (products.Count == 0)
                {
                    Console.WriteLine("No product");
                    return;
                }
                foreach (var item in products)
                {
                    table.AddRow(item.Name,item.Price,item.Category,item.Quantity,item.Id);
                }
                table.Write();
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("Oops");
                Console.WriteLine(ex.Message);
            }
        }
        public static void SearchProductsByName()
        {
            try
            {
                Console.WriteLine("Enter product name: ");
                var name=Console.ReadLine();
                var products = projectService.SearchProductsByName(name);
                var table = new ConsoleTable("Name", "Price", "Category", "Quantity", "Id");

                if (products.Count == 0)
                {
                    Console.WriteLine("No product found!");
                    return;
                }
                foreach (var item in products)
                {
                    table.AddRow(item.Name, item.Price, item.Category, item.Quantity, item.Id);
                }
                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Oops");
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateProduct()
        {
            try
            {

                Console.WriteLine("Enter Id:");
                int Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new name:");
                string Name = Console.ReadLine();

                Console.WriteLine("Enter new quantity:");
                int Quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Categories is available:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }
                Console.WriteLine("Enter category id of the new product:");
                int categoryId = int.Parse(Console.ReadLine());

                if (!Enum.IsDefined(typeof(Category), categoryId))
                {
                    Console.WriteLine("Category is inappropriate!");
                    return;
                }

                  Category Category = (Category)categoryId;

                Console.WriteLine("Enter new price:");
                decimal newPrice = decimal.Parse(Console.ReadLine());
                ProjectService.EditProduct(Id, Name, Quantity, categoryId, newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }


                #endregion


                #region Sale
                public static void MenuSale()
        {

        }
        #endregion


        #region SaleItem
        public static void MenuSaleItem()
        {

        }
        #endregion


    }
}
