using FinalProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Enums;

namespace FinalProject.Models
{
    class Product
    {
        public Product(string name,string surname,ProductCategory category,string productCount,string productId) 
        {
            this.Name = name;
            this.Surname = surname;
            this.Category = category;   
            this.ProductCount = productCount;
            this.ProductId = productId;
            
        }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public ProductCategory Category { get; set; }
        public string ProductCount { get; set; }
        public string ProductId { get; set; }
    }
}
