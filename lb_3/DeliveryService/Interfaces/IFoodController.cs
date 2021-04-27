using DeliveryService.Models;
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
        Food CreateFood(string name, decimal price, float weight, string type);
    }
}
