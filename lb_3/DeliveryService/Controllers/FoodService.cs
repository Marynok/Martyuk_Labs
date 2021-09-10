using DeliveryService.Interfaces;
using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.Controllers
{
    public class FoodService: IFoodService
    {
        private readonly IRepository<Food> _food;
        private readonly IRepository<FoodType> _foodTypes;
        private readonly IUnitOfWork _unitOfWork;
        public FoodService(IUnitOfWork unitOfWork)
        {
            _food = unitOfWork.FoodRepository;
            _foodTypes = unitOfWork.FoodTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public FoodType SearchFoodType(string name)
        {
            return _foodTypes.GetSome(f => f.Name == name).FirstOrDefault();
        }

        public FoodType CreateFoodType(string name)
        {
            var foodType = SearchFoodType(name);
            if (foodType is null)
            {
                foodType = new FoodType() { Name = name };
                _foodTypes.Add(foodType);
            }
            return foodType;
        }

        public Food CreateFood(string name, decimal price, float weight, string type)
        {
            var foodType = CreateFoodType(type);
            var food = new Food() { Name = name, Price = price, Weight = weight, Type = foodType };
            _food.Add(food);
            return food;
        }

        public Food UpdateFood(Food food, string name, decimal price, float weight, string type)
        {
            var foodType = CreateFoodType(type);
            food.Name = name;
            food.Price = price;
            food.Weight = weight;
            food.Type = foodType;

            _food.Update(food);
            return food;
        }

        public void DeleteFood(Food food)
        {
            _food.Delete(food.Id);
        }

        public IEnumerable<Food> Get()
        {
            return _food.GetAll();
        }

        public Food SearchFood(int id)
        {
            return _food.GetOne(id);
        }

        public Food UpdateFood(Food food)
        {
            if (food is null || SearchFood(food.Id) is null)
            {
                return null;
            }

            _food.Update(food);
            _unitOfWork.Save();

            return food;
        }

        public Food CreateFood(Food food)
        {
            if (food is null)
            {
                return null;
            }

            _food.Add(food);
            _unitOfWork.Save();

            return food;
        }

        public bool DeleteFood(int id)
        {
            if (SearchFood(id) is null)
            {
                return false;
            }

            _food.Delete(id);
            _unitOfWork.Save();

            return true;
        }

    }
}
