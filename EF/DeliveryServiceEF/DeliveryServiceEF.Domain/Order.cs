using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryServiceEF.Domain.BaseModel;

namespace DeliveryServiceEF.Domain
{ 
    public class Order: Model
    {
       public int ClientId { get; set; }
        public Client Client { get; set; }
        public OrderStatus Status { get; set; }
        public Delivery Delivery { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get => SetTotalPrie(); }
        public string ClientNumber { get; set; }
        public IList<OrderFoodData> OrderFoods { get; set; }
        public Order()
        {
            Date = DateTime.Now;
            OrderFoods = new List<OrderFoodData>();
        }

        public Order(String clientNumber) 
        {
            ClientNumber = clientNumber;
            Date = DateTime.Now;
            OrderFoods = new List<OrderFoodData>();
        }

        public Order(int id, String phone) : base(id)
        {
            ClientNumber = phone;
            Date = DateTime.Now;
            OrderFoods = new List<OrderFoodData>();
        }

        private decimal SetTotalPrie()
        {
            return OrderFoods.Sum(food => food.Count * food.TotalPrice);
        }

        public override string ToString()
        {
            return $"data:{Date} number:{ClientNumber} price:{TotalPrice}$";
        }

    }
}
