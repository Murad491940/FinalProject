using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30.Services
{
   
        public static class SubMenuHelper
        {
            public static void ProductsSubMenu()
            {
                Console.Clear();
                int option;
                do
                {
                    Console.WriteLine("1.Add a new product ");
                    Console.WriteLine("2.Make a correction on the product ");
                    Console.WriteLine("3.Delete product");
                    Console.WriteLine("4.Show all products");
                    Console.WriteLine("5.Show products by category");
                    Console.WriteLine("6.Show products according to the price range");
                    Console.WriteLine("7.Search among products by name");
                    Console.WriteLine("0.Exit");

                    Console.WriteLine("-----------");
                    Console.WriteLine("Enter option:");

                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid number!");
                        Console.WriteLine("-----------");
                        Console.WriteLine("Enter option:");
                    }

                    switch (option)
                    {
                        case 1:
                            MenuService.MenuAddProduct();
                            
                            break;
                        case 2:
                            MenuService.MenuEditProduct();
                           
                            break;
                        case 3:
                            MenuService.MenuDeleteProduct();
                            
                            break;
                        case 4:
                            MenuService.MenuProducts();
                            
                            break;
                        case 5:
                            MenuService.MenuShowProductsByCategory();
                          
                            break;
                        case 6:
                            MenuService.MenuDisplayProductsByPriceRange();
                            
                            break;
                        case 7:
                            MenuService.MenuSearchProductsByName();
                           
                            break;
                        case 0:
                            break;
                        default:
                            
                            break;
                    }

                } while (option != 0);
            }

            public static void SalesSubMenu()
            {
                Console.Clear();
                int option;
                do
                {
                    Console.WriteLine("1.Adding a new sale ");
                    Console.WriteLine("2.Returning any product on sale (withdrawal from sale) ");
                    Console.WriteLine("3.Deletion of the sale ");
                    Console.WriteLine("4.Display of all sales ");
                    Console.WriteLine("5.Display of sales according to the given date range");
                    Console.WriteLine("6.Display of sales according to the range of the given amount");
                    Console.WriteLine("7.Show sales on the given date");
                    Console.WriteLine("8. Show sales according to their numbers");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("-----------");
                    Console.WriteLine("Enter option:");

                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid number!");
                        Console.WriteLine("-----------");
                        Console.WriteLine("Enter option:");
                    }

                    switch (option)
                    {
                        case 1:
                            
                            MenuService.MenuAddSales();
                            break;
                        case 2:
                          
                            MenuService.RefundProduct();
                            break;
                        case 3:
                            
                            MenuService.RemoveSale();
                            break;
                        case 4:
                            
                            MenuService.MenuShowAllSales();
                            break;
                        case 5:
                            
                            MenuService.ShowSaleByTimeInterval();
                            break;
                        case 6:
                            
                            MenuService.ShowSaleByPriceInterval();
                            break;
                        case 7:
                            
                            break;
                        case 8:
                            
                            MenuService.MenuShowAllSales();
                            var currentSaleId = Int32.Parse(Console.ReadLine());
                            MenuService.ShowSaleDetailsById(currentSaleId);
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Bye!");
                            break;
                    }

                } while (option != 0);
            }
        }
}
