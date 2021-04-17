using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.models.baseModel;

namespace DeliveryService.models
{
    public class Food: Model
    {
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public FoodType Type { get; set; }

        public Company FoodCompany { get; set; }
    }
}
