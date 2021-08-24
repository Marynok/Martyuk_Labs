using DeliveryService.Models.Base;

namespace DeliveryService.Models
{
    public class Address : BaseModel
    {
        public string StreetName { get; set; }
        public string HouseNumberName { get; set; }

        public override string ToString()
        {
            return $"Street: {StreetName}, House number: {HouseNumberName}";
        }
    }
}

