using DeliveryService.LinqTask;
using DeliveryService.Models;
using System;
using System.Collections.Generic;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = new List<FoodType> { 
                new FoodType("Drink"), 
                new FoodType("Roll"), 
                new FoodType("Pizza") }
            ;

            var foods = new List<Food> { 
                new Food("Cola", 50, 100, types[0]), 
                new Food("Albin Pizza", 200, 100, types[0]), 
                new Food("Bol", 50, 100, types[1]) 
            };
            var foods2 = new List<Food> { 
                new Food("Coca", 50, 100, types[0]), 
                new Food("Havai Pizza ", 200, 100, types[2]), 
                new Food("Bol", 50, 100, types[1]) 
            };

            var manuf = new List<Manufacturer> { 
                new Manufacturer("Mascon", null, default) { Foods = new List<Food>(foods) },
                new Manufacturer("Sanson", null, default) { Foods = new List<Food>(foods2) },
                new Manufacturer("Purpone", null, default)
            };

            foods.AddRange(foods2);

            var linq = new LINQuery(manuf, types, foods);

            linq.PrintList(linq.GetSortFoods());

            linq.PrintList(linq.GetFoodsManufacturersName());

            linq.PrintList(linq.GetCountFoodInTypes());

            linq.PrintList(linq.GetCountFoodInManufacturers());

            linq.PrintList(linq.GetCommonFoodForTwoManufacturers(manuf[0], manuf[1]));
         
            linq.PrintList(linq.GetUniqueFood(manuf[0], manuf[2]));
        }
    }
}
