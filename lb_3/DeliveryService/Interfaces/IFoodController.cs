using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IFoodController
    {
        FoodType SearchFoodType(string name);
        FoodType CreateFoodType(string name);
        Food SearchFood(int id);
        IEnumerable<Food> Get();
        Food CreateFood(string name, decimal price, float weight, string type);
        Food UpdateFood(Food food, string name, decimal price, float weight, string type);
        void DeleteFood(Food food);
    }
}
