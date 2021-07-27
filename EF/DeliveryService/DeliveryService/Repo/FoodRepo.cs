using Dapper;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DeliveryService.Repo
{
    public class FoodRepo : IFoodRepository, IFoodWithObjectsRepository
    {
        readonly private IDbConnection db;
  
        public FoodRepo(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }
        public bool AddFood(Food food)
        {
            
            return AddFoodWithObjects(food); 
        }

        public bool UpdateFood(Food food)
        {
            var sqlQuery = @"UPDATE Foods SET  Name = @Name, Price = @Price, Weight = @Weight
                             WHERE FoodId = @FoodId";
            db.Execute(sqlQuery, food);
            return true;
        }

        public void DeleteFood(int id)
        {
            var sqlQuery = "DELETE FROM Foods WHERE FoodId = @Id";
            db.Execute(sqlQuery, new { Id = id });
        }

        public Food GetFoodById(int id)
        {
            return db.Query<Food>("SELECT * FROM Foods WHERE FoodId = @Id", new { Id = id }).SingleOrDefault();
        }

        public List<Food> GetFoods()
        {
            return db.Query<Food>("SELECT * FROM Foods").ToList();
        }

        private void ExecuteQueryWithAllDatas(string query, Food food)
        {
            db.Execute(query, new
            {
                FoodId = food.FoodId,
                Name = food.Name,
                FoodType = food.Type.FoodTypeId,
                Price = food.Price,
                ManufacturerId = food.Manufacturer.ManufacturerId,
                Weight = food.Weight
            });

        }
        public bool AddFoodWithObjects(Food food)
        {
            if (!(food.Manufacturer is null && food.Type is null))
            {
                var query = @"INSERT INTO Foods (FoodId, Name, FoodTypeId,  Price,  ManufacturerId, Weight)
                         VALUES(@FoodId, @Name, @FoodType,  @Price,  @ManufacturerId, @Weight)";
                ExecuteQueryWithAllDatas(query, food);
                return true;
            }
            return false;
        }

        public bool UpdateFoodWithObjects(Food food)
        {
            if (!(food.Manufacturer is null && food.Type is null))
            {
                var query = @"UPDATE Foods
                          SET Name = @Name, FoodTypeId = @FoodType,  Price = @Price,  ManufacturerId = @ManufacturerId , Weight = @Weight
                          WHERE FoodId = @FoodId";
                ExecuteQueryWithAllDatas(query, food);
                return true;
            }
            return false;
        }

        public void DeleteFoodWithObjects(int manufacturerId)
        {
            var query = "DELETE FROM Foods WHERE ManufacturerId = @Id";

            db.Execute(query, new { Id = manufacturerId });
        }
        private IEnumerable<Food> GetFodsByQuery(string conditionOfSelect = default, int? id = null)
        {
            var sql = @"SELECT * 
                        FROM Foods as f
                        LEFT JOIN Manufacturers as m
                        ON f.ManufacturerId = m.ManufacturerId
                        LEFT JOIN FoodTypes as ft
                        ON f.FoodTypeId = ft.FoodTypeId " + conditionOfSelect;

            return db.Query<Food, Manufacturer, FoodType, Food>(sql,
                                        (food, manufacturer, type) =>
                                        {
                                            food.Manufacturer = manufacturer;
                                            food.Type = type;
                                            return food;
                                        }, new { Id = id }
                                    , splitOn: "ManufacturerId, FoodTypeId ");
        }

        public List<Food> GetFoodsWithObjects()
        {
            var foods = GetFodsByQuery().ToList(); ;
            return foods;
        }

        public Food GetFoodByIdWithObjects(int id)
        {
            var food = GetFodsByQuery("WHERE FoodId = @Id", id).Distinct().FirstOrDefault();
            return food;
        }
    }
}
