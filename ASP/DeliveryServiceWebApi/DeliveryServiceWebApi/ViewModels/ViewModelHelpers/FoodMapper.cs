using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.ViewModels.ViewModelHelpers
{
    public class FoodMapper
    {
        public Food Map(FoodModel foodModel)
        {
            return new Food()
            {
                Id = foodModel.Id,
                Name = foodModel.Name,
                ManufacturerId = foodModel.ManufacturerId,
                TypeId = foodModel.TypeId,
                Weight = foodModel.Weight,
                Price = foodModel.Price,
            };
        }

        public FoodModel Map(Food food)
        {
            return new FoodModel()
            {
                Id = food.Id,
                Name = food.Name,
                ManufacturerId = food.ManufacturerId,
                TypeId = food.TypeId,
                Weight = food.Weight,
                Price = food.Price,
                Manufacturer = Map(food.Manufacturer),
                Type = Map(food.Type)
            };
        }

        public ManufacturerModel Map(Manufacturer manufacturer ) 
        {
            return new ManufacturerModel()
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            };
        }

        public FoodTypeModel Map(FoodType foodType ) 
        {
            return new FoodTypeModel()
            {
                Id = foodType.Id,
                Name = foodType.Name
            };

        }
    }
}
