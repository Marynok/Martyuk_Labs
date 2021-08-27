using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class Food : BaseModel
    {
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int TypeId { get; set; }
        public FoodType Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public IList<OrderFoodData> OrderFoodDatas { get; set; }
  
        public override string ToString()
        {
            return $"{base.Id} {Name} {Weight} {Price}$ {Type.Name}";
        }
    }
}
