using DeliveryService.Models.Base;
using System;

namespace DeliveryService.Models
{
    public class Food : BaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public FoodType Type { get; set; }

        public override string ToString()
        {
            return $"{base.Id} {Name} {Weight} {Price} {Type.Name}$";
        }
    }
}
