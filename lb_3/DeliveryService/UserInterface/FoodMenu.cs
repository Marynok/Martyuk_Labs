using DeliveryService.Interfaces;

using DeliveryService.UserInterface.Check;
using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface
{
    public class FoodMenu : IMenu
    {
        private readonly string[] _foodMenuItems = new string[] { "Show products", "Create new product", "Update product", "Delete product", "Exit" };
        private readonly string[] _changeMenuItems = new string[] { "Select product", "Exit" };
        private readonly IFoodService _foodService;
        private readonly IManufacturerService _manufacturerService;
        private delegate void ChangeFood(Food food);
        public FoodMenu(IFoodService foodService, IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
            _foodService = foodService;
        }
        public async Task Start()
        {
            var checkMenu = true;
            while (checkMenu)
            {
                Console.Clear();
                BaseConsoleFunction.WithdrawList(_foodMenuItems);
                var checkItem = Checker.GetPropertyInt(Console.ReadLine());
                switch (checkItem)
                {
                    case 1:
                        ShowProducts();
                        break;
                    case 2:
                        CreateNewProduct();
                        break;
                    case 3:
                        ChangeProduct(Action.UPDATE);
                        break;
                    case 4:
                        ChangeProduct(Action.DELETE);
                        break;
                    case 5:
                        checkMenu = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect data");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void CreateNewProduct()
        {
            Console.Clear();
            var name = BaseConsoleFunction.GetProperty("Enter product name");
            var price = Checker.GetPropertyDecimal(BaseConsoleFunction.GetProperty("Enter price"));
            var weight = Checker.GetPropertyFloat(BaseConsoleFunction.GetProperty("Enter weight"));
            var type = BaseConsoleFunction.GetProperty("Enter type");

            if (BaseConsoleFunction.CheckArea("Want to confirm your actions? y/n", "y"))
            {
                var food = _foodService.CreateFood(name, price, weight, type);
                Console.WriteLine($"{food} was created!");
                Console.ReadLine();
            }
        }
        public void ChangeProduct(Action action)
        {
            var checkMenu = true;
            while (checkMenu)
            {
                Console.Clear();
                BaseConsoleFunction.WithdrawList(_changeMenuItems);
                BaseConsoleFunction.ConsoleDelimiter();
                BaseConsoleFunction.WithdrawList(_manufacturerService.Manufacturer.Foods.ToArray());
                var checkItem = Checker.GetPropertyInt(Console.ReadLine());
                switch (checkItem)
                {
                    case 1:
                        CheckProduct(action);
                        break;
                    case 2:
                        checkMenu = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect data");
                        Console.ReadLine();
                        break;
                }
            }

        }
        public void CheckProduct(Action action)
        {
            var id = Checker.GetPropertyInt(BaseConsoleFunction.GetProperty("Enter product number"));
            var food = _foodService.SearchFood(id);
            if (food is null)
                BaseConsoleFunction.GetProperty("This product does not exist");
            else
            {
                if (action == Action.UPDATE)
                    UpdateProduct(food);
                else
                    DeleteProduct(food);
            }
        }
        public void DeleteProduct(Food food)
        {
            if (BaseConsoleFunction.CheckArea($"You want delete {food} ? y/n", "y"))
            {
                _foodService.DeleteFood(food);
                BaseConsoleFunction.GetProperty($"This product: {food} was deleted");
            }
        }
        public void UpdateProduct(Food food)
        {
            var name = (BaseConsoleFunction.CheckArea($"You want update name ? y/n", "y")? 
                BaseConsoleFunction.GetProperty("Enter new name")
                : food.Name);
            var price = (BaseConsoleFunction.CheckArea($"You want update price ? y/n", "y") ?
                Checker.GetPropertyDecimal(BaseConsoleFunction.GetProperty("Enter new price"))
                : food.Price);
            var weight = (BaseConsoleFunction.CheckArea($"You want update weight ? y/n", "y") ? 
                Checker.GetPropertyFloat(BaseConsoleFunction.GetProperty("Enter new weight"))
                : food.Weight);
            var type = (BaseConsoleFunction.CheckArea($"You want update type ? y/n", "y") ? 
                BaseConsoleFunction.GetProperty("Enter new type")
                : food.Type.Name);

            if (BaseConsoleFunction.CheckArea($"You want update {food} ? y/n", "y"))
            {
               var newFood = _foodService.UpdateFood(food, name, price, weight, type);
                BaseConsoleFunction.GetProperty($"This product: {newFood} was updated");
            }
        }

        public void ShowProducts()
        {
            Console.Clear();
            BaseConsoleFunction.WithdrawList(_manufacturerService.Manufacturer.Foods.ToArray());
            Console.ReadLine();
        }
    }
}
