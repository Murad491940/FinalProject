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
        public Sale(string saleNumber) 
        { 
            SaleNumber = saleNumber;
        }
        
        public string SaleNumber { get; set; }
        public decimal SalePrice { get; set; }
        public SaleItem İtem { get; set; }   
        public DateTime SaleTime { get; set; } 

       
    }
}
