using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Models.Base;

namespace DeliveryService.Models
{
    public class Order: BaseModel
    {
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public string ClientNumber { get; set; }
        public Address Address { get; set; }
        public IList<OrderFoodData> Foods { get; set; }
   
        public override string ToString()
        {
            return $"data:{Date} number:{ClientNumber} price:{TotalPrice}$";
        }

    }
}
