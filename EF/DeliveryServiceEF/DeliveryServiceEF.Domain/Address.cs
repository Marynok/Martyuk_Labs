using DeliveryServiceEF.Domain.BaseModel;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class Address : Model
    {
        public string StreetName { get; set; }
        public string HouseNumberName { get; set; }
        public IList<Manufacturer> Manufacturers { get; set; }
        public IList<Delivery> Deliveries { get; set; }
        public Address() { }

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

