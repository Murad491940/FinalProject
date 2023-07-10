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
        public Product(string name,string surname) 
        {
            this.Name = name;
            this.Surname = surname;

        }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public ProductCategory Ctegory { get; set; }
        public string ProductCount { get; set; }
        public string ProductId { get; set; }
    }
}
