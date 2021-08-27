using DeliveryServiceEF.Domain.Base;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain 
{ 
    public class FoodType: BaseModel
    {
        public string Name { get; set; }
        public IList<Food> Foods { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
