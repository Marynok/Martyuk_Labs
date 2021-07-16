using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    class Delivery: Model
    {
        Order Order { get; set; }
        DeliveryMan DeliveryMan { get; set; }
        DateTime TimeStart { get; set; }
        DateTime TimeEnd { get; set; }
        decimal Price { get; set; }
        public Delivery(Order order, decimal price) 
        {
            Order = order;
            Price = price;
        }

        public Delivery(Order order, decimal price, int id):base(id)
        {
            Order = order;
            Price = price;
        }

        public override string ToString()
        {
            return $"";
        }
    }
}
