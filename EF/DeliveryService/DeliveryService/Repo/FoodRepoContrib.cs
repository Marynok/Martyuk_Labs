using Dapper;
using Dapper.Contrib.Extensions;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Repo
{
    public class FoodRepoContrib : IFoodRepository, IFoodWithObjectsRepository
    {
        readonly private IDbConnection db;
        public FoodRepoContrib(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
      
        public bool AddFood(Food food)
        {
            return AddFoodWithObjects(food);
        }
        public bool UpdateFood(Food food)
        {
            db.Update(food);
            return true;
        }
        public void DeleteFood(int id)
        {
            db.Delete(db.Get<Food>(id));
        }

        public Food GetFoodById(int id)
        {
            return db.Get<Food>(id);
        }

        public List<Food> GetFoods()
        {
            return db.GetAll<Food>().ToList();
        }

        public bool AddFoodWithObjects(Food food)
        {
            if (!(food.Manufacturer is null && food.Type is null))
            {
                var newFood = new FoodTable(food);
                db.Insert(newFood);
                return true;
            }
            return false;
        }

        public bool UpdateFoodWithObjects(Food food)
        {
            if (!(food.Manufacturer is null && food.Type is null))
            {
                var updateFood = new FoodTable(food);
                db.Update(updateFood);
                return true;
            }
            return false;
        }

        public void DeleteFoodWithObjects(int manufacturerId)
        {
            var getFoodsIdQuery = "SELECT * FROM Foods WHERE ManufacturerId = @Id";
            var foods= db.Query<Food>(getFoodsIdQuery, new { Id = manufacturerId }).ToList();

            foreach (var food in foods)
                db.Delete(food);
        }

        private IEnumerable<Food> GetFodsByQuery(string conditionOfSelect = default, int? id = null)
        {
            var sql = "SELECT FoodId, Name, Price, Weight, FoodTypeId, ManufacturerId FROM Foods " + conditionOfSelect;
            return db.Query<Food, long, long, Food>(sql,
                (food, foodTypeId, manufacturerId) =>
                {
                    food.Manufacturer = db.Get<Manufacturer>(manufacturerId);
                    food.Type = db.Get<FoodType>(foodTypeId);
                    return food;
                }, new { Id = id }, splitOn: "FoodTypeId, ManufacturerId").ToList();
        }

        public Food GetFoodByIdWithObjects(int id)
        {
            return GetFodsByQuery("WHERE FoodId = @Id", id).FirstOrDefault();
        }

        public List<Food> GetFoodsWithObjects()
        {
           return GetFodsByQuery().ToList();
        }
    }
}
