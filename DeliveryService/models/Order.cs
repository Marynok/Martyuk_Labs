using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
    public class Order: Model
    {
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Address Address { get; set; }
        public IList<OrderFoodData> Foods { get; set; }
        public Order(int id, Address address) : base(id)
        {
            Address = address;
            Date = DateTime.Now;
            Foods = new List<OrderFoodData>();
        }

    }
}
