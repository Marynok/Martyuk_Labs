using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class FoodController: IFoodController
    {
        private readonly IDatabaseController<Food> _food;
        private readonly IDatabaseController<FoodType> _foodTypes;
        public FoodController(IDatabaseController<Food> food, IDatabaseController<FoodType> foodTypes)
        {
            _food = food;
            _foodTypes = foodTypes;
        }

        public FoodType SearchFoodType(string name)
        {
            return _foodTypes.Search(f => f.Name == name);
        }
        public Food SearchFood(int id)
        {
            var food = _food.Search(f => f.Id == id);
            return food;
        }
        public FoodType CreateFoodType(string name)
        {
            var foodType = SearchFoodType(name);
            if (foodType is null)
            {
                foodType = new FoodType(name);
                _foodTypes.AddModel(foodType);
            }
            return foodType;
        }
        public Food CreateFood(string name, decimal price, float weight, string type)
        {
            var foodType = CreateFoodType(type);
            var food = new Food(name, price, weight, foodType);
            _food.AddModel(food);
            return food;
        }
        public Food UpdateFood(Food food, string name, decimal price, float weight, string type)
        {
            var foodType = CreateFoodType(type);
            var updatedFood = new Food(name, price, weight, foodType);
            updatedFood.Id = food.Id;
            _food.Update(food, updatedFood);
            return updatedFood;
        }
        public void DeleteFood(Food food)
        {
            _food.Delete(food);
        }
    }
}
