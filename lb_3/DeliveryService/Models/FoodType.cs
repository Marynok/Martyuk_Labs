using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
    public class FoodType:Model
    {
        public string Name { get; set; }
        [JsonConstructor]
        public FoodType( string name) 
        {
            Name = name;
        }
        public FoodType(int id, string name) : base(id)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
