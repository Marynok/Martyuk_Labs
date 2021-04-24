using DeliveryService.Abstracts;
using DeliveryService.DataBase;
using DeliveryService.DataController;
using DeliveryService.UserInterface.Check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface
{
    public class MainMenu
    {
        private string[] menuItems = new string[] { "I am manufacturer", "I am client" };
        private ServiceMenu _serviceMenu;
        public void Start(DataBaseController dataBaseController)
        {
            _serviceMenu = null;
            Console.WriteLine("Press Number");
            BaseConsoleFunction.WithdrawList(menuItems);
            while (_serviceMenu is null)
            {
                var checkItem = Checker.GetPropertyInt(Console.ReadLine());
                _serviceMenu = checkItem switch
                {
                    1 => new ManufacturerMenu(this, dataBaseController),
                    2 => new ClientMenu(this, dataBaseController),
                    _ => null
                };
                if (_serviceMenu is null)
                    Console.WriteLine("Input value outside the menu ");
            }
            _serviceMenu.PersonalArea();
        }
    }
}
