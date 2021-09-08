using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.ViewModels
{
    public class FoodModel
    {
        public int Id { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        public ManufacturerModel Manufacturer { get; set; }

        [Required]
        public int TypeId { get; set; }
        public FoodTypeModel Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public float Weight { get; set; }
    }
}
