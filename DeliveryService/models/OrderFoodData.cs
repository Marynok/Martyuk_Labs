using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public struct OrderFoodData
    {
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }
        public Food Foods { get; set; }
    }
}
