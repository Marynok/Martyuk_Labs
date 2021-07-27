using Dapper.Contrib.Extensions;
using DeliveryService.Models.BaseModel;
using System;


namespace DeliveryService.Models
{
    public class Food 
    {
        [Key]
        public int FoodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Write(false)]
        public Manufacturer Manufacturer { get; set; }
        public double Weight { get; set; }
        [Write(false)]
        public FoodType Type { get; set; }
        public Food() { }

        public Food(string name, decimal price, FoodType type)
        {
            Name = name;
            Price = price;
            Type = type;
        }

        public Food(int id, string name, decimal price, double weight) 
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{FoodId} {Name} {Weight} {Price}$ type: {Type?.FoodTypeId} {Type?.Name},  manufacturer: {Manufacturer?.Name}";
        }
    }
}
