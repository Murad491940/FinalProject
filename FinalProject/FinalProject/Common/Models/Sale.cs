using FinalProject.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Common.Models
{
    public class Sale : BseEntity
    {
        private static int _count = 0;
        
        public Sale() 
        {
            Id = _count;
            _count++;
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public List<SaleItem> SaleItems { get; set; }

    }
}
