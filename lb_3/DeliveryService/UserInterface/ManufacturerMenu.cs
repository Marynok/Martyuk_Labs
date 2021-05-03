using DeliveryService.Abstracts;
using DeliveryService.Controllers;
using DeliveryService.Interfaces;
using DeliveryService.UserInterface.Check;
using System;
using System.Linq;

namespace DeliveryService.UserInterface
{
    public class ManufacturerMenu : ServiceMenu
    {
        private readonly string[] _cabinetMenuItems = new string[] { "Show products", "Create new product", "Exit" };
        private IFoodController _foodController;
        public ManufacturerMenu(IMenu mainMenu, IManufacturerController manufacturerController,
            IFoodController foodController, IAddressController addressController) : base(mainMenu, addressController, manufacturerController)
        {
            _foodController = foodController;
        }
        public override void SignIn()
        {
            ManufacturerController.SearchManufacturer("MacMod");
            PersonalArea();
        }
        public override void Registrate()
        { }
        public override void PersonalArea()
        {
            var checkMenu = true;
            while (checkMenu)
            {
                Console.Clear();
                Console.WriteLine(ManufacturerController.Manufacturer.Name);

                BaseConsoleFunction.WithdrawList(_cabinetMenuItems);
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
                        checkMenu = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect data");
                        Console.ReadLine();
                        break;
                }
            }
            Exit();
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
                var food = _foodController.CreateFood(name, price, weight, type);
                ManufacturerController.AddFood(food);
                Console.WriteLine($"{food} was created!");
                Console.ReadLine();
            }
        }
        public void ShowProducts()
        {
            Console.Clear();
            BaseConsoleFunction.WithdrawList(ManufacturerController.Manufacturer.Foods.ToArray());
            Console.ReadLine();
        }
    }
}
