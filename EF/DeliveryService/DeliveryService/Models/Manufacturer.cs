using System;
using System.Collections.Generic;
using DeliveryService.Models.Base;

namespace DeliveryService.Models
{
    public class Manufacturer : BaseModel
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public IList<Food> Foods { get; set; } = new List<Food>();

        public override string ToString()
        {
            return $"{base.Id} {Name}";
        }
    }
}
