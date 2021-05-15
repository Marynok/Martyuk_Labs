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
        private IManufacturerController _manufacturerController;
        private IClientController _clientController;
        private IAddressController _addressController;
        private IFoodController _foodontroller;
        private IBasketController _basketController;
        public MainMenu(IManufacturerController manufacturerController, IClientController clientController, IAddressController addressController,
           IFoodController foodontroller, IBasketController basketController )
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
                    1 => new ManufacturerMenu(this, new FoodMenu(_foodontroller, _manufacturerController), _manufacturerController, _addressController),
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
