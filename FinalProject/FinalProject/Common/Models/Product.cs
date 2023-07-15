using FinalProject.Common.Base;
using FinalProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Common.Models
{
    public class Product: BseEntity
    {
        private static int _count = 0;
        public Product() 
        {
            Id = _count;
            _count++;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
       
    }
}
