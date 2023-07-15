using FinalProject.Services;

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
                Console.WriteLine("4.Butun mehsullari goster");
                Console.WriteLine("5.Kateqoriyaya gore mehsullari sil");
                Console.WriteLine("6.Qiymet araligina gore mehsullari goster");
                Console.WriteLine("7.Mehsullar arsinda ada gore axtaris et");

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
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    break;
               


            }
            while(option != 3);

            MarketableService marketableService = new MarketableService();
            marketableService.AddSale("1", 100, Enums.SaleItem.Product,"10.04.2027");
        }
    }
}