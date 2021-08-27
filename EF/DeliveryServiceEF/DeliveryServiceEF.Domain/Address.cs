using DeliveryServiceEF.Domain.Base;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class Address : BaseModel
    {
        public string StreetName { get; set; }
        public string HouseNumberName { get; set; }
        public IList<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
        public IList<Delivery> Deliveries { get; set; }

        public override string ToString()
        {
            return $" Id : {Id} Street: {StreetName}, House number: {HouseNumberName}";
        }
    }
}

