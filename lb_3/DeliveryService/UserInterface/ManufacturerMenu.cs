using DeliveryService.DataBase;
using DeliveryService.Models;
using DeliveryService.UserInterface.Check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface
{
    public class ManufacturerMenu : ServiceMenu
    {
        readonly string[] cabinetMenuItems = new string[] { "Show products", "Create new product", "Exit" };
        private Manufacturer _manufacturer;
        public ManufacturerMenu(MainMenu mainMenu, DeliveryDataBase deliveryDataBase) : base(mainMenu, deliveryDataBase) 
        {
            _manufacturer = deliveryDataBase.SearchManufacturer("MacMod");
        }
        public override void SignIn()
        { }
        public override void Registr()
        { }
        public override void PersonalArea()
        {
            var checkMenu = true;
            while (checkMenu) 
            {
                Console.Clear();
                Console.WriteLine(_manufacturer.Name);

                BaseConsoleFunction.WithdrawList(cabinetMenuItems);
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

            if (BaseConsoleFunction.CheckAreae("Want to confirm your actions? y/n", "y"))
            {
                var food = base.DeliveryDataBase.CreateFood(name, price, weight, type, _manufacturer);
                Console.WriteLine($"{food} was created!");
                Console.ReadLine();
            }
        }
        public void ShowProducts()
        {
            Console.Clear();
            BaseConsoleFunction.WithdrawList(_manufacturer.Foods.ToArray());
            Console.ReadLine();
        }
    }
}
