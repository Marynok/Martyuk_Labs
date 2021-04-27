using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Collections.Generic;

namespace DeliveryService.Controllers
{
    public class ManufacturerController
    {
        public Manufacturer Manufacturer;
        public readonly IDatabaseController<Manufacturer> Manufacturers;
        public ManufacturerController(IDatabaseController<Manufacturer> manufacturers)
        {
            Manufacturers = manufacturers;
        }
        public Manufacturer SearchManufacturer(string Name)
        {
            Manufacturer = Manufacturers.Search(m => m.Name == Name);
            return Manufacturer;
        }
        public Manufacturer SearchManufacturer(int id)
        {
            Manufacturer = Manufacturers.Search(m => m.Id == id);
            return Manufacturer;
        }
        public Manufacturer CreateManufacturer(string name, Address address, string description)
        {
            var _manufacturer = SearchManufacturer(name);
            if (_manufacturer is null)
            {
                _manufacturer = new Manufacturer(name, address, description);
                Manufacturers.AddModel(_manufacturer);
            }
            else
                _manufacturer = null;
            return _manufacturer;
        }
        public void AddFood(Food food)
        {
            Manufacturer.Foods.Add(food);
        }
        public IEnumerable<Food> GetFoods()
        { 
            return Manufacturer.Foods;
        }
    }
}





