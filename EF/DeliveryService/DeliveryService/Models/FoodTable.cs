using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    [Table("Foods")]
    public class FoodTable
    {
        [ExplicitKey]
        public int FoodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public int? FoodTypeId { get; set; } = 0;
        public int? ManufacturerId { get; set; } = 0;
        public FoodTable(Food food)
        {
            FoodId = food.FoodId;
            Name = food.Name;
            Price = food.Price;
            Weight = food.Weight;
            FoodTypeId = food.Type?.FoodTypeId;
            ManufacturerId = food.Manufacturer?.ManufacturerId;
        }
    }

}
