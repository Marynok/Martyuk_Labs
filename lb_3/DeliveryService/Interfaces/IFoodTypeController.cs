using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IFoodTypeController
    {
        FoodType SearchFoodType(int id);
        IEnumerable<FoodType> Get();
        FoodType CreateFoodType(FoodType food);
        FoodType UpdateFoodType(FoodType food);
        bool DeleteFoodType(int id);
    }
}
