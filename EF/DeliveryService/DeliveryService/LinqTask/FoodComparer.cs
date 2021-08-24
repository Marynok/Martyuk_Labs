using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.LinqTask
{
    public class FoodComparer: IEqualityComparer<Food>
    {
        public bool Equals(Food x, Food y)
        {
            if (x is null || y is null)
                return false;

            return x.Name == y.Name;
        }

        public int GetHashCode(Food food)
        {
            if (food is null) return 0;
            return food.Name == null ? 0 : food.Name.GetHashCode();
        }
    }
}
