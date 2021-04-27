using DeliveryService.Controllers;
using DeliveryService.Interfaces;
using DeliveryService.UserInterface.Check;
using System;

namespace DeliveryService.UserInterface
{
    public class MainMenu: IMenu
    {
        private readonly string[] _menuItems = new string[] { "I am manufacturer", "I am client" };
        private IMenu _serviceMenu;
        private ManufacturerController _manufacturerController;
        private ClientController _clientController;
        private AddressController _addressController;
        private FoodController _foodontroller;
        private BasketController _basketController;
        public MainMenu(ManufacturerController manufacturerController, ClientController clientController, AddressController addressController,
           FoodController foodontroller, BasketController basketController )
        {
            _clientController = clientController;
            _manufacturerController = manufacturerController;
            _addressController = addressController;
            _foodontroller = foodontroller;
            _basketController = basketController;
        }
        public void Start()
        {
            _serviceMenu = null;
            Console.WriteLine("Press Number");
            BaseConsoleFunction.WithdrawList(_menuItems);
            while (_serviceMenu is null)
            {
                var checkItem = Checker.GetPropertyInt(Console.ReadLine());
                _serviceMenu = checkItem switch
                {
                    1 => new ManufacturerMenu(this, _manufacturerController, _foodontroller, _addressController),
                    2 => new ClientMenu(this, _clientController, _basketController, _addressController, _manufacturerController),
                    _ => null
                };
                if (_serviceMenu is null)
                    Console.WriteLine("Input value outside the menu ");
            }
            _serviceMenu.Start();
        }
    }
}
