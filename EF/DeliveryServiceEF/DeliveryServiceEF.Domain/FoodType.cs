using DeliveryServiceEF.Domain.BaseModel;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain 
{ 
    public class FoodType:Model
    {
        public string Name { get; set; }
        public IList<Food> Foods { get; set; }

        public FoodType() { }
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
