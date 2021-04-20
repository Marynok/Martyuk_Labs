using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
    public class Food: Model
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public FoodType Type { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Food(int id, string name, decimal price, float weight, FoodType type) : base(id)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Type = type;
        }
    }
}
