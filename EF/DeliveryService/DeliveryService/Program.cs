using DeliveryService.Settings;
using DeliveryService.LinqTask;
using DeliveryService.Models;
using DeliveryService.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = new SettingDb("appsettings.json").ConnectionString;
            var foodrepo = new FoodRepository(connectionString);
            var foodrepoContrib = new FoodRepositoryContrib(connectionString);

            var food = foodrepoContrib.GetFoodByIdWithObjects(9);
            food.FoodId = 18;
            foodrepoContrib.AddFood(food);
            food.Price = 6770;
            foodrepoContrib.UpdateFoodWithObjects(food);
            foodrepoContrib.DeleteFoodWithObjects(3);
            foodrepoContrib.DeleteFood(18);

            var foods = foodrepoContrib.GetFoodsWithObjects();

            foreach (var fc in foods)
                Console.WriteLine(fc);
        }
    }
}
