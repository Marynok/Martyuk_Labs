using DeliveryService.Abstracts;
using DeliveryService.Controllers;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using DeliveryService.UserInterface.Check;
using System;
using System.Linq;

namespace DeliveryService.UserInterface
{
    public class ManufacturerMenu : ServiceMenu
    {
        private readonly string[] _cabinetMenuItems = new string[] { "Edit products", "Exit" };
        private readonly IMenu _foodMenu;
        public ManufacturerMenu(IMenu mainMenu, IMenu foodMenu, IManufacturerController manufacturerController,
             IAddressController addressController) : base(mainMenu, addressController, manufacturerController)
        {
            _foodMenu = foodMenu;
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
                        _foodMenu.Start();
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

            Exit();
        }
       
    }
}
