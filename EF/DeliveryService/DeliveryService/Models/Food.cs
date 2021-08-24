using DeliveryService.Models.Base;
using Dapper.Contrib.Extensions;
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

        public override string ToString()
        {
            return $"{FoodId} {Name} {Weight} {Price}$ type: {Type?.FoodTypeId} {Type?.Name},  manufacturer: {Manufacturer?.Name}";
        }
    }
}
