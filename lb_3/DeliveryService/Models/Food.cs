using DeliveryService.Models.BaseModel;
using System;
using System.Text.Json.Serialization;

namespace DeliveryService.Models
{
    public class Food : Model
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public FoodType Type { get; set; }
        [JsonConstructor]
        public Food(string name, decimal price, float weight, FoodType type)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Type = type;
        }
        public Food(int id, string name, decimal price, float weight, FoodType type) : base(id)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Type = type;
        }
        public override string ToString()
        {
            return $"{base.Id} {Name} {Weight} {Price} {Type.Name}$";
        }
    }
}
