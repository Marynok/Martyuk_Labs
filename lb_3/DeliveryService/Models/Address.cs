using DeliveryService.Models.BaseModel;
using System.Text.Json.Serialization;

namespace DeliveryService.Models
{
    public class Address : Model
    {
        public string StreetName { get; set; }
        public string HouseNumberName { get; set; }
        [JsonConstructor]
        public Address(string streetName, string houseNumberName)
        {
            StreetName = streetName;
            HouseNumberName = houseNumberName;
        }

        public Address(int id, string streetName, string houseNumber) : base(id)
        {
            StreetName = streetName;
            HouseNumberName = houseNumber;
        }
        public override string ToString()
        {
            return $"Street: {StreetName}, House number: {HouseNumberName}";
        }
    }
}

