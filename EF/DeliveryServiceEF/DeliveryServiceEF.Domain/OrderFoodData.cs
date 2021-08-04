using DeliveryServiceEF.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DeliveryServiceEF.Domain
{
    public class OrderFoodData:Model
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderFoodData() { }

        public OrderFoodData(int count, Food food)
        {
            Count = count;
            Food = food;
            TotalPrice = food.Price;
        }

        public override string ToString()
        {
            return $" {Food.Name} {TotalPrice}$ {Count}pc.";
        }
    }
}
