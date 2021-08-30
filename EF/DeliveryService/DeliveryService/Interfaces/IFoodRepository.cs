using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IFoodRepository
    {
        List<Food> GetFoods();
        Food GetFoodById(int id);
        bool AddFood(Food food);
        bool UpdateFood(Food food);
        void DeleteFood(int id);
        List<Food> GetFoodsWithObjects();
        Food GetFoodByIdWithObjects(int id);
        bool AddFoodWithObjects(Food food);
        bool UpdateFoodWithObjects(Food food);
        void DeleteFoodWithObjects(int manufacturerId);
    }
}
