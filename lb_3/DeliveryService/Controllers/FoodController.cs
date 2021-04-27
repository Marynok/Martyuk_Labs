using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class FoodController
    {
        public readonly IDatabaseController<Food> Food;
        public readonly IDatabaseController<FoodType> FoodTypes;
        public FoodController(IDatabaseController<Food> food, IDatabaseController<FoodType> foodTypes)
        {
            Food = food;
            FoodTypes = foodTypes;
        }

        public FoodType SearchFoodType(string name)
        {
            return FoodTypes.Search(f => f.Name == name);
        }
        public FoodType CreateFoodType(string name)
        {
            var foodType = SearchFoodType(name);
            if (foodType is null)
            {
                foodType = new FoodType(name);
                FoodTypes.AddModel(foodType);
            }
            return foodType;
        }
        public Food CreateFood(string name, decimal price, float weight, string type)
        {
            var foodType = CreateFoodType(type);
            var food = new Food(name, price, weight, foodType);
            Food.AddModel(food);
            return food;
        }
    }
}
