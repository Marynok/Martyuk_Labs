using DeliveryService.Abstracts;
using DeliveryService.Controllers;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using DeliveryService.UserInterface.Check;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface
{
    public class ManufacturerMenu : ServiceMenu
    {
        private readonly string[] _cabinetMenuItems = new string[] { "Edit products", "Exit" };
        private readonly IMenu _foodMenu;
        public ManufacturerMenu(IMenu mainMenu, IMenu foodMenu, IManufacturerService manufacturerService,
             IAddressController addressController) : base(mainMenu, addressController, manufacturerService)
        {
            _foodMenu = foodMenu;
        }
        public override async Task SignIn()
        {
            manufacturerService.SearchManufacturer("MacMod");
            PersonalArea();
        }
        public override void Registrate()
        { }
        public void PersonalArea()
        {
            var checkMenu = true;
            while (checkMenu)
            {
                Console.Clear();
                Console.WriteLine(manufacturerService.Manufacturer.Name);

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
