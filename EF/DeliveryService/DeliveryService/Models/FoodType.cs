using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
    public class FoodType:Model
    {
        public string Name { get; set; }

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
