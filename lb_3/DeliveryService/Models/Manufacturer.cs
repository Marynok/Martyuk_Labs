using System;
using System.Collections.Generic;
using DeliveryService.Models.BaseModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Manufacturer : Model
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public IList<Food> Foods { get; set; }
        public Manufacturer(string name, Address address, string description)
        {
            Name = name;
            Address = address;
            Description = description;
            Foods = new List<Food>();
        }
        public Manufacturer(int id, string name, Address address, string description) : base(id)
        {
            Name = name;
            Address = address;
            Description = description;
            Foods = new List<Food>();
        }
       
        public override string ToString()
        {
            return $"{base.Id} {Name}";
        }

    }
}
