using ConsoleApp30.Enums;
using ConsoleApp30.Models;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp30.Services
{
    public class MenuService
    {
        private static MarketService marketService = new();

        #region Product

        /// <summary>
        /// Showing products
        /// </summary>
        public static void MenuProducts()
        {
            try
            {
                var products = marketService.GetProducts();

                var table = new ConsoleTable("Name", "Price", "Category",
                    "Count", "Product Code");

                if (products.Count == 0)
                {
                    Console.WriteLine("No product's yet.");
                    return;
                }

                foreach (var item in products)
                {
                    table.AddRow(item.Name, item.Price, item.Category,
                        item.Count, item.Id);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adding new products
        /// </summary>
        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter product's price:");
                decimal price = decimal.Parse(Console.ReadLine());

                if (price <= 0)
                {
                    throw new Exception("Price must be positive");
                }

                Console.WriteLine("Enter product's category:");
                foreach (var item in Enum.GetNames(typeof(Category)))
                {
                    Console.WriteLine(item);
                }
                string category = Console.ReadLine().ToUpper();

                Console.WriteLine("Enter product's count:");
                int id = int.Parse(Console.ReadLine());

                if (id <= 0)
                {
                    throw new Exception("Count must be positive");
                }
                int Id = marketService.AddProduct(name, price, category, id);
                Console.WriteLine($"Added product with product code: {Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Deleting existing products
        /// </summary>
        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product's code:");
                int Id = int.Parse(Console.ReadLine());

                Console.WriteLine($"Successfully deleted product with Number: {Id}");
                marketService.DeleteProduct(Id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Showing products for category
        /// </summary>
        public static void MenuShowProductsByCategory()
        {
            try
            {

                Console.WriteLine("Enter category: ");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine(category);
                }

                string Category = Console.ReadLine();
                if (Enum.TryParse<Category>(Category, out Category _Category))
                {
                    Console.WriteLine($"Entered category: {Category}");
                    var products = marketService.ShowProductsByCategory(_Category);

                    var table = new ConsoleTable("Name", "Price", "Category",
                        "Count", "Product ID");

                    if (products.Count == 0)
                    {
                        Console.WriteLine("Not found!");
                        return;
                    }

                    foreach (var item in products)
                    {
                        table.AddRow(item.Name, item.Price, item.Category,
                            item.Count, item.Id);
                    }

                    table.Write();
                }
                else
                {
                    Console.WriteLine("Not found!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Showing products for prices
        /// </summary>
        public static void MenuDisplayProductsByPriceRange()
        {
            try
            {
                Console.WriteLine("Enter minimum product price:");
                int MinimumPrice = int.Parse(Console.ReadLine());


                Console.WriteLine("Enter highest product price:");
                int HighPrice = int.Parse(Console.ReadLine());

                if (MinimumPrice < 0 && HighPrice < 0)
                {
                    throw new Exception("Value cannot be negative");
                }

                var products = marketService.DisplayProductsByPriceRange(MinimumPrice, HighPrice);
                var table = new ConsoleTable("Name", "Price", "Category", "Count", "Product Code");

                if (products.Count == 0)
                {
                    Console.WriteLine("Not found");
                    return;
                }

                foreach (var item in products)
                {
                    table.AddRow(item.Name, item.Price, item.Category, item.Count, item.Id);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Showing products for names
        /// </summary>
        public static void MenuSearchProductsByName()
        {
            try
            {
                Console.WriteLine("Enter name:");
                var name = Console.ReadLine();
                var products = marketService.SearchProductsByName(name);
                var table = new ConsoleTable("Name", "Price", "Category", "Count", "Product ID");

                if (products.Count == 0)
                {
                    Console.WriteLine("Not found!");
                    return;
                }

                foreach (var item in products)
                {
                    table.AddRow(item.Name, item.Price, item.Category, item.Count, item.Id);
                }

                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Oops! error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Editing products properties
        /// </summary>
        public static void MenuEditProduct()
        {
            try
            {
                Console.WriteLine("Enter ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the new quantity:");
                int quantity = int.Parse(Console.ReadLine());
                if (quantity < 0)
                {
                    throw new Exception("error");
                }

                Console.WriteLine("Available categories:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }
                Console.WriteLine("Enter category id of the nproduct:");
                int categoryID = int.Parse(Console.ReadLine());
                if (categoryID < 0)
                {
                    throw new Exception("error");
                }

                if (!Enum.IsDefined(typeof(Category), categoryID))
                {
                    Console.WriteLine("Not found!");
                    return;
                }
                Category Category = (Category)categoryID;

                Console.WriteLine("Enter price:");
                decimal newPrice = decimal.Parse(Console.ReadLine());
                marketService.EditProduct(id, name, quantity, categoryID, newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }


        #endregion

        #region Sales
        /// <summary>
        /// Adding new sales for user inputs
        /// </summary>
        public static void MenuAddSales()
        {
            bool product = true;
            List<SaleItem> saleItems = new List<SaleItem>();

            while (product)
            {
                Console.Clear();
                Console.WriteLine("Enter product id: ");
                MenuService.MenuProducts();
                var productID = Int32.Parse(Console.ReadLine());

                if (productID < 0)
                {
                    throw new Exception("The product id cannot be less than 0!");
                }

                Console.WriteLine("Enter product quantity : ");

                var quantity = Int32.Parse(Console.ReadLine());

                if (quantity <= 0)
                {
                    throw new Exception("error");
                }

                var CommonProduct = marketService.Products.FirstOrDefault(e => e.Id == productID);

                var SaleItem = new SaleItem(CommonProduct, quantity);

                saleItems.Add(SaleItem);

                Console.WriteLine("Do you want to continue?");
                var option = Console.ReadLine();
                if (option.ToLower() != "y")
                {
                    product = false;
                }
            }

            var amount = saleItems.Select(e => e.Product.Price * e.Count).Sum();

            Sale sale = new Sale(amount, saleItems);

            marketService.AddSale(sale);


            //Product product = new Product("kola", 4, Category.A, 3, 0);
            //List<SaleItem> saleItems = new List<SaleItem>();
            //SaleItem saleItem = new SaleItem(1, product, 2);
            //saleItems.Add(saleItem);

        }

        /// <summary>
        /// Showing all existing sales
        /// </summary>
        public static void MenuShowAllSales()
        {
            var table = new ConsoleTable("Number", "Amount",
                   "SaleTime");

            var sales = marketService.Sales;

           

            foreach (var item in sales)
            {
                table.AddRow(item.Number, item.Amount, item.SaleTime);
            }

            table.Write();
        }

        /// <summary>
        /// Showing existing sales for datetime
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public static void MenuShowAllSalesByTimeInterval(DateTime date, DateTime _date)
        {
            var table = new ConsoleTable("Id", "Amount",
                   "SaleTime");

            var sales = marketService.Sales.Where(i => i.SaleTime >= date && i.SaleTime <= _date).ToList();

            if (sales.Count == 0)
            {
                Console.WriteLine("No sales found.");
                return;
            }

            foreach (var item in sales)
            {
                table.AddRow(item.Number, item.Amount, item.SaleTime);
            }

            table.Write();
        }

        /// <summary>
        /// Showing existing sales for amount
        /// </summary>
        /// <param name="fromPrice"></param>
        /// <param name="toPrice"></param>
        public static void MenuShowAllSalesByPriceInterval(decimal price, decimal _price)
        {
            var table = new ConsoleTable("Id", "Amount", "SaleTime");
            var sales = marketService.Sales.Where(i => i.SaleItems.Select(e => e.Product.Price * e.Count).Sum() >= price && i.SaleItems.Select(e => e.Product.Price * e.Count).Sum() <= _price).ToList();

            if (sales.Count == 0)
            {
                Console.WriteLine("No sales found.");
                return;
            }

            foreach (var item in sales)
            {
                table.AddRow(item.Number, item.Amount, item.SaleTime);
            }

            table.Write();
        }

        /// <summary>
        /// Showing sales details for user
        /// </summary>
        /// <param name="saleId"></param>
        public static void ShowSaleDetailsById(int saleId)
        {

            var sale = marketService.Sales.FirstOrDefault(e => e.Number == saleId);

            var SaleProducts = sale.SaleItems;

            var table = new ConsoleTable("Id", "Name", "Price", "Category", "Quantity");

            var sales = marketService.Sales;

            if (SaleProducts.Count == 0)
            {
                Console.WriteLine("No product's yet.");
                return;
            }

            foreach (var saleItem in SaleProducts)
            {
                table.AddRow(saleItem.Id, saleItem.Product.Name, saleItem.Product.Price, saleItem.Product.Category,saleItem.Count);
            }

            table.Write();
        }

        /// <summary>
        /// Refunding products to stock and increasing products again
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void RefundProduct()
        {
            MenuShowAllSales();
            Console.WriteLine("Enter number to return: ");
            var currentSaleNumber = Int32.Parse(Console.ReadLine());
            var currentSale = marketService.Sales.FirstOrDefault(e => e.Number == currentSaleNumber);

            if (currentSaleNumber < 0)
            {
                throw new Exception("Sales number cannot be less than 0");
            }
            if (currentSale is not null)
            {
                ShowSaleDetailsById(currentSaleNumber);
                Console.WriteLine("Enter product id to return : ");
                var currentProductId = Int32.Parse(Console.ReadLine());
                if (currentProductId < 0)
                {
                    throw new Exception("Product id cannot be less than 0\"");
                }
                var currentSaleItem = currentSale.SaleItems.FirstOrDefault(i => i.Id == currentProductId);
                var currentProductQuantityInSale = currentSale.SaleItems.FirstOrDefault(i => i.Id == currentProductId).Count;

                Console.WriteLine($"Enter the product number to return : {currentProductQuantityInSale}");
                var currentProductQuantity = Int32.Parse(Console.ReadLine());
                if (currentProductQuantityInSale < currentProductQuantity)
                {
                    throw new Exception("Oops error!");
                }
                else
                {
                    currentSaleItem.Count -= currentProductQuantity;
                    marketService.IncreaseProductQuantity(currentSaleItem.Product.Id, currentProductQuantity);
                }

            }


          
        }

        /// <summary>
        /// Removing sale and saleitems 
        /// </summary>
        public static void RemoveSale()
        {
            try
            {
                MenuShowAllSales();
                Console.WriteLine("Choose sale number for remove : ");
                var SaleID = Int32.Parse(Console.ReadLine());
                if (SaleID < 0)
                {
                    throw new Exception("Sale number must be positive");
                }
                var sale = marketService.Sales.FirstOrDefault(e => e.Number == SaleID);

                marketService.Sales.Remove(sale);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");
            }

        }

        /// <summary>
        /// Showing sales for datetime
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void ShowSaleByTimeInterval()
        {
            try
            {
                Console.WriteLine("Enter from date : (dd/mm/yyyy)");
                var date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter to date : (dd/mm/yyyy)");
                var _date = DateTime.Parse(Console.ReadLine());

                if (_date <= date)
                {
                    throw new Exception("FromDate cannot be lower from ToDate");
                }

                MenuShowAllSalesByTimeInterval(date, _date);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");
            }

        }

        /// <summary>
        /// Showing sales for price
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void ShowSaleByPriceInterval()
        {
            try
            {
                Console.WriteLine("Enter from price : ");
                var price = Decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter to price : ");
                var _price = Decimal.Parse(Console.ReadLine());

                if (price <= 0 && _price <= 0)
                {
                    throw new Exception("Price must positive");
                }
                if (_price <= price)
                {
                    throw new Exception("FromPrice cannot be lower from ToPrice");
                }

                MenuShowAllSalesByPriceInterval(price, _price);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");
            }
            #endregion
        }
}   }
