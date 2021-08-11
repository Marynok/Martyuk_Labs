using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class Manufacturer : BaseModel
    {
        public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public IList<Food> Foods { get; set; }

        public override string ToString()
        {
            return $"{base.Id} {Name}";
        }
    }
}
