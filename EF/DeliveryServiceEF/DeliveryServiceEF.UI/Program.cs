using DeliveryServiceEF.Data;
using DeliveryServiceEF.Domain;
using DeliveryServiceEF.UI.DataWorkers;
using DeliveryServiceEF.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryServiceEF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           var _context = new DataContext();
            _context.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(_context);

            CreateDatas(unitOfWork);
            DeleteDatas(unitOfWork);
            UpdateDatas(unitOfWork);

        }

        static void CreateDatas(IUnitOfWork unitOfWork)
        {
            var address = new Address() { StreetName = "Sokolova", HouseNumberName = "40" };
            var man1 = new Manufacturer() { Name = "SanSan11", Address = address };
            var man2 = new Manufacturer() { Name = "Macron21", Address = address };
            var man3 = new Manufacturer() { Name = "Sereon31", Address = address };

            var foodType1 = new FoodType() { Name = "Pizza" };
            unitOfWork.ManufacturerRepository.Add(man1);
            unitOfWork.Save();

            var food1 = new Food() { Name = "Vegan Pizza11", Manufacturer = unitOfWork.ManufacturerRepository.GetAll().First(), Price = 300, Weight = 200, Type = foodType1 };

            var foodType2 = new FoodType() { Name = "Water" };

            var food2 = new Food() { Name = "Vegan Pizza21", Manufacturer = man1, Price = 300, Weight = 200, Type = foodType2 };
            var food3 = new Food() { Name = "Vegan Pizza31", Manufacturer = man2, Price = 300, Weight = 200, Type = foodType2 };

            var food4 = new Food() { Name = "Potato Free41", Manufacturer = man3, Price = 355, Weight = 200, Type = foodType1 };
            var food5 = new Food() { Name = "Cola5", Manufacturer = man3, Price = 50, Weight = 100, Type = foodType1 };


            var foodType3 = new FoodType() { Name = "FastFood", Foods = new List<Food>() { food4, food5 } };

            unitOfWork.FoodRepository.Add(new List<Food>() { food1, food2, food3 });
            unitOfWork.FoodTypeRepository.Add(foodType3);
            unitOfWork.Save();

        }

        static void DeleteDatas(IUnitOfWork unitOfWork)
        {
            unitOfWork.ManufacturerRepository.Delete(3);
            unitOfWork.Save();
        }

        static void UpdateDatas(IUnitOfWork unitOfWork)
        {
            var food = unitOfWork.FoodRepository.GetOne(3);
            food.Name = "CocaCola";
            food.Type = unitOfWork.FoodTypeRepository.GetSome(ft => ft.Name == "Water").FirstOrDefault();
            unitOfWork.FoodRepository.Update(food);
            unitOfWork.Save();
        }

    }
}
