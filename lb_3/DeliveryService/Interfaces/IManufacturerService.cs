
using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IManufacturerService
    {
        Manufacturer Manufacturer { get; }
        Manufacturer SearchManufacturer(string Name);
        Manufacturer CreateManufacturer(string name, Address address, string description);
        void AddFood(Food food);
        IEnumerable<Food> GetFoods();
        void RemoveFood(Food food);
        IEnumerable<Manufacturer> GetAll();
        Manufacturer SearchManufacturer(int id);
        Manufacturer CreateManufacturer(Manufacturer manufacturer);
        Manufacturer UpdateManufacturer(Manufacturer manufacturer);
        bool DeleteManufacturer(int id);
    }
}
