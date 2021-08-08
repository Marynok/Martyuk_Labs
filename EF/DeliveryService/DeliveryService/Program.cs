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
                new FoodType(){Name ="Drink" }, 
                new FoodType(){Name ="Roll" }, 
                new FoodType(){Name ="Pizza" } }
            ;

            var foods = new List<Food> { 
                new Food(){Name="Cola", Price = 50, Weight = 100, Type = types[0] }, 
                new Food(){Name="Albin Pizza", Price = 200, Weight = 100, Type = types[0] }, 
                new Food() {Name="Bol", Price = 50, Weight = 100, Type = types[1] }
            };
            var foods2 = new List<Food> { 
                new Food(){Name="Coca", Price = 50, Weight = 100, Type = types[0] }, 
                new Food(){Name="Havai Pizza", Price = 200, Weight = 100, Type = types[2] }, 
                new Food(){Name="Bol", Price = 50, Weight = 100, Type = types[1] }
            };

            var manuf = new List<Manufacturer> { 
                new Manufacturer() {Name ="Mascon", Foods = new List<Food>(foods) },
                new Manufacturer() {Name ="Sanson", Foods = new List<Food>(foods2) },
                new Manufacturer(){Name = "Purpone" }
            };

            foods.AddRange(foods2);

            var manager = new FoodManager(manuf, types, foods);

            manager.PrintList(manager.GetSortFoods());

            manager.PrintList(manager.GetFoodsManufacturersName());

            manager.PrintList(manager.GetCountFoodInTypes());

            manager.PrintList(manager.GetCountFoodInManufacturers());

            manager.PrintList(manager.GetCommonFoodForTwoManufacturers(manuf[0], manuf[1]));

            manager.PrintList(manager.GetUniqueFood(manuf[0], manuf[1]));
        }
    }
}
