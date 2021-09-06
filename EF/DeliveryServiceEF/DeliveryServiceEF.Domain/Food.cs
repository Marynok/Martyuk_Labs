using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryServiceEF.Domain
{
    public class Food : BaseModel
    {
        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Required]
        public int TypeId { get; set; }
        public FoodType Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public float Weight { get; set; }
        public IList<OrderFoodData> OrderFoodDatas { get; set; }
  
        public override string ToString()
        {
            return $"{base.Id} {Name} {Weight} {Price}$ {Type?.Name}";
        }
    }
}
