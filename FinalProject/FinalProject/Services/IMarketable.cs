using FinalProject.Enums;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    interface IMarketable
    {
     public Sale[] Sales { get; set; }
     void AddSale(string salenumber, decimal price, SaleItem sale, DateTime dateTime);



    }
}
