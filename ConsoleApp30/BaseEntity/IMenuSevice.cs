using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30.Base
{
    public interface IMenuService
    {
        void MenuProducts();
        void MenuAddProduct();

        void MenuDeleteProduct();
        void ShowProductsByCategory();
        void MenuDisplayProductsByPriceRange();
        void MenuSearchProductsByName();
        void MenuEditProduct();
        void MenuAddSales();
        void MenuShowAllSales();
        void MenuShowAllSalesByTimeInterval(DateTime fromDate, DateTime toDate);
        void MenuShowAllSalesByPriceInterval(decimal fromPrice, decimal toPrice);
        void ShowSaleDetailsById(int saleId);
        void RefundProduct();
        void RemoveSale();
        void ShowSaleByTimeInterval();
        void ShowSaleByPriceInterval();
    }
}
