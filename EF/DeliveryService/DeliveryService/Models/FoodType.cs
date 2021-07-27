using Dapper.Contrib.Extensions;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
    public class FoodType 
    {
        [Key]
        public int FoodTypeId { get;set;}
        public string Name { get; set; }

        public FoodType() { }

        public FoodType( string name) 
        {
            Name = name;
        }

        public override string ToString()
        {
            return $" { FoodTypeId} Name: {Name}";
        }
    }
}
