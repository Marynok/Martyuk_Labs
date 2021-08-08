using DeliveryService.Models.Base;

namespace DeliveryService.Models
{
    public class FoodType: BaseModel
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}
