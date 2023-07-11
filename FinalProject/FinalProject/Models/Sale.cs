using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Enums;

namespace FinalProject.Models
{
    class Sale
    {
        public Sale(string saleNumber,decimal price,SaleItem item,DateTime saletime) 
        { 
            SaleNumber = saleNumber;
            SalePrice = price;
            Item = item;
            SaleTime = saletime;


        }
        
        public string SaleNumber { get; set; }
        public decimal SalePrice { get; set; }
        public SaleItem Item { get; set; }   
        public DateTime SaleTime { get; set; } 

       
    }
}
