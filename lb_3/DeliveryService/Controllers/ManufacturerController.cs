using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Collections.Generic;

namespace DeliveryService.Controllers
{
    public class ManufacturerController:IManufacturerController
    {
        private Manufacturer _manufacturer;
        public Manufacturer Manufacturer { get => _manufacturer; }
        private readonly IDatabaseController<Manufacturer> _manufacturers;
        public ManufacturerController(IDatabaseController<Manufacturer> manufacturers)
        {
            _manufacturers = manufacturers;
        }
        public Manufacturer SearchManufacturer(string Name)
        {
            _manufacturer = _manufacturers.Search(m => m.Name == Name);
            return Manufacturer;
        }
        public Manufacturer SearchManufacturer(int id)
        {
            _manufacturer = _manufacturers.Search(m => m.Id == id);
            return Manufacturer;
        }
        public Manufacturer CreateManufacturer(string name, Address address, string description)
        {
             _manufacturer = SearchManufacturer(name);
            if (_manufacturer is null)
            {
                _manufacturer = new Manufacturer(name, address, description);
                _manufacturers.AddModel(_manufacturer);
            }
            else
                _manufacturer = null;
            return _manufacturer;
        }
        public void AddFood(Food food)
        {
            _manufacturer.Foods.Add(food);
        }
        public IEnumerable<Food> GetFoods()
        { 
            return _manufacturer.Foods;
        }
        public void RemoveFood(Food food)
        {
            _manufacturer.Foods.Remove(food);
        }
        public IEnumerable<Manufacturer> GetAll()
        {
            return _manufacturers.GetAll();
        }

    }
}





