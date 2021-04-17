using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.models.baseModel;

namespace DeliveryService.models
{
    public class Order: Model
    {
        public decimal Price { get; set; }
        public int CountItems { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Address OrderAddress { get; set; }
        public List<Food> Foods { get; set; }
    }
}
