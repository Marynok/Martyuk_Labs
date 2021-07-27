using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using DeliveryService.Models.BaseModel;



namespace DeliveryService.Models
{
    public class Manufacturer 
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public IList<Food> Foods { get; set; }

        public Manufacturer() { }

        public Manufacturer(string name, Address address, string description)
        {
            Name = name;
            Address = address;
            Description = description;
            Foods = new List<Food>();
        }

        public Manufacturer(int id, string name, Address address, string description) 
        {
            Name = name;
            Address = address;
            Description = description;
            Foods = new List<Food>();
        }
       
        public override string ToString()
        {
            return $"{ManufacturerId} {Name} {Phone}";
        }
    }
}
