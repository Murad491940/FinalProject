using FinalProject.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Common.Models
{
    public class SaleItem : BseEntity
    {
        public int Number { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
       
    }
}
