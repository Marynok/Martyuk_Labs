using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryServiceEF.Domain.Base;

namespace DeliveryServiceEF.Domain
{ 
    public class Order: BaseModel
    {
       public int ClientId { get; set; }
        public Client Client { get; set; }
        public OrderStatus Status { get; set; }
        public Delivery Delivery { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public string ClientNumber { get; set; }
        public IList<OrderFoodData> OrderFoods { get; set; }

        public override string ToString()
        {
            return $"data:{Date} number:{ClientNumber} price:{TotalPrice}$";
        }

    }
}
