using DeliveryServiceEF.Domain.BaseModel;
using System;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class Food : Model
    {
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int TypeId { get; set; }
        public FoodType Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public IList<OrderFoodData> OrderFoodDatas { get; set; }
        public Food() { }
       
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
            return $"{base.Id} {Name} {Weight} {Price}$ {Type.Name}";
        }
    }
}
