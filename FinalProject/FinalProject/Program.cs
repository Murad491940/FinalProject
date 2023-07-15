using FinalProject.Common.Services;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;

            do
            {
                Console.WriteLine("1.Yeni mehsul elave et");
                Console.WriteLine("2.Mehsul uzerinde duzelis et");
                Console.WriteLine("3.Mehsulu sil");
               

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Enter option:");

            }
            while (!int.TryParse(Console.ReadLine(), out option));
            {
               
                Console.WriteLine("Invalid Number!");
                Console.WriteLine("-----------------");
                Console.WriteLine("Enter option:");

            }
            switch(option)
            {
                case 1:
                   SubMenuServıice.ProductSubMenu();
                    break;
                case 2:
                    SubMenuServıice.SaleSubMenu();
                    break;
                case 0:
                    Console.WriteLine("Bye!");
                    break;
                default: Console.WriteLine("No such option!");
                    
                break;
           
            }
            while(option != 0);

           
        }
    }
}