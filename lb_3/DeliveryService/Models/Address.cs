using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
    public class Address : Model
    {
        public string StreetName { get; set; }
        public string HouseNumberName { get; set; }
        public Address(string streetName, string houseNumber)
        {
            StreetName = streetName;
            HouseNumberName = houseNumber;
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

