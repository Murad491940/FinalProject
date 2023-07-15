using FinalProject.Common.Services;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Common.Services
{
    public class SubMenuServıice()
    {
        public static void ProductSubMenu()
        {
            Console.Clear();
            int option;
            do
            {
                Console.WriteLine("1.Yeni mehsul elave et");
                Console.WriteLine("2.Mehsul uzerinde duzelis et");
                Console.WriteLine("3.Mehsulu sil");
                Console.WriteLine("4.Butun mehsullari goster");
                Console.WriteLine("5.Kateqoriyaya gore mehsullari sil");
                Console.WriteLine("6.Qiymet araligina gore mehsullari goster");
                Console.WriteLine("7.Mehsullar arsinda ada gore axtaris et");

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Enter option:");

            }
            while (!int.TryParse(Console.ReadLine(), out option));
            {

                Console.WriteLine("Invalid Number!");
                Console.WriteLine("-----------------");
                Console.WriteLine("Enter option:");

            }
            switch (option)
            {
                case 1:
                    MenuService.MenuProduct();
                    break;
                case 2:
                    break;
                case 3:
                    MenuService.MenuAddProduct();
                    break;
                case 4:
                    MenuService.MenuDelateProduct();
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 0:
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("No such option!");

                    break;

            }
            while (option != 0) ;

        }
        public static void SaleSubMenu()
        {
            Console.Clear();
            int option;
            do
            {
                Console.WriteLine("1.Yeni mehsul elave et");
                Console.WriteLine("2.Mehsul uzerinde duzelis et");
                Console.WriteLine("3.Mehsulu sil");
                Console.WriteLine("4.Butun mehsullari goster");
                Console.WriteLine("5.Kateqoriyaya gore mehsullari sil");
                Console.WriteLine("6.Qiymet araligina gore mehsullari goster");
                Console.WriteLine("7.Mehsullar arsinda ada gore axtaris et");

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Enter option:");

            }
            while (!int.TryParse(Console.ReadLine(), out option));
            {

                Console.WriteLine("Invalid Number!");
                Console.WriteLine("-----------------");
                Console.WriteLine("Enter option:");

            }
            switch (option)
            {
                case 1:
                    MenuService.MenuAddProduct();
                    break;
                case 2:
                    break;
                case 3:
                    MenuService.MenuDelateProduct();
                    break;
                case 4:
                    MenuService.MenuProduct();

                    break;
                case 5:
                    MenuService.ShowProductsByCategory();
                    break;
                case 6:
                    MenuService.DisplayProductsByPriceRange();
                    break;
                case 7:
                    MenuService.SearchProductsByName();
                    break;
                case 0:
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("No such option!");

                break;

            }
            while (option != 0) ;


        }


    }
}
    
    

          
    

