using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IManufacturerController
    {
        Manufacturer Manufacturer { get; }
        Manufacturer SearchManufacturer(string Name);
        Manufacturer SearchManufacturer(int id);
        Manufacturer CreateManufacturer(string name, Address address, string description);
        IEnumerable<Manufacturer> GetAll();
        void AddFood(Food food);
        IEnumerable<Food> GetFoods();
    }
}
