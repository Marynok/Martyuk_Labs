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
        public Order Order { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal Price { get; set; }
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
