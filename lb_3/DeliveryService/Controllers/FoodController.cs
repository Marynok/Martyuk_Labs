using DeliveryService.Interfaces;
using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.Controllers
{
    public class FoodController: IFoodController
    {
        private readonly IRepository<Food> _food;
        private readonly IRepository<FoodType> _foodTypes;
        public FoodController(IUnitOfWork unitOfWork)
        {
            _food = unitOfWork.FoodRepository;
            _foodTypes = unitOfWork.FoodTypeRepository;
        }

        public FoodType SearchFoodType(string name)
        {
            return _foodTypes.GetSome(f => f.Name == name).FirstOrDefault();
        }

        public Food SearchFood(int id)
        {
            return _food.GetOne(id);
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
    }
}
