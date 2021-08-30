using DeliveryService.Interfaces;
using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.Controllers
{
    public class ManufacturerController: IManufacturerController
    {
        private Manufacturer _manufacturer;
        public Manufacturer Manufacturer { get => _manufacturer; }
        private readonly IFullRepository<Manufacturer> _manufacturers;
        private readonly IUnitOfWork _unitOfWork;

        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _manufacturers = unitOfWork.ManufacturerRepository;
            _unitOfWork = unitOfWork;
        }

        public Manufacturer SearchManufacturer(string Name)
        {
            _manufacturer = _manufacturers.GetSome(m => m.Name == Name).FirstOrDefault();
            return Manufacturer;
        }

        public Manufacturer SearchManufacturer(int id)
        {
            return _manufacturers.GetOneWithObjects(id);
        }

        public Manufacturer CreateManufacturer(string name, Address address, string description)
        {
             _manufacturer = SearchManufacturer(name);
            if (_manufacturer is null)
            {
                _manufacturer = new Manufacturer() {Name = name,Address = address,Description = description };
                _manufacturers.Add(_manufacturer);
            }
            else
                _manufacturer = null;
            return _manufacturer;
        }

        public void AddFood(Food food)
        {
            _manufacturer.Foods.Add(food);
            _manufacturers.Update(_manufacturer);
        }

        public IEnumerable<Food> GetFoods()
        { 
            return _manufacturer.Foods;
        }

        public void RemoveFood(Food food)
        {
            var removeFood = _manufacturer.Foods.FirstOrDefault(f => f.Id == food.Id);
            _manufacturer.Foods.Remove(removeFood);
            _manufacturers.Update(_manufacturer);
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return _manufacturers.GetAllWithObjects();
        }

        public Manufacturer CreateManufacturer(Manufacturer manufacturer) 
        {
            if (manufacturer is null)
            {
                return null;
            }

            _manufacturers.Add(manufacturer);
            _unitOfWork.Save();

            return manufacturer;
        }
        public Manufacturer UpdateManufacturer(Manufacturer manufacturer) 
        {
            if (manufacturer is null || SearchManufacturer(manufacturer.Id) is null)
            {
                return null;
            }

            _manufacturers.Add(manufacturer);
            _unitOfWork.Save();

            return manufacturer;
        }
        public bool DeleteManufacturer(int id)
        {
            if (SearchManufacturer(id) is null)
            {
                return false;
            }

            _manufacturers.Delete(id);
            _unitOfWork.Save();

            return true;
        }
    }
}





