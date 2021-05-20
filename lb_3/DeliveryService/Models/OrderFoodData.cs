using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class OrderFoodData
    {
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }
        public Food Food { get; set; }
        [JsonConstructor]
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
