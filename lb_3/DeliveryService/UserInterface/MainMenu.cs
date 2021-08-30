using DeliveryService.Controllers;
using DeliveryService.Interfaces;
using DeliveryService.UserInterface.Check;
using System;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface
{
    public class MainMenu: IMenu
    {
        private readonly string[] _menuItems = new string[] { "I am manufacturer", "I am client" };
        private IMenu _serviceMenu;
        private readonly IManufacturerController _manufacturerController;
        private readonly IClientController _clientController;
        private readonly IAddressController _addressController;
        private readonly IFoodController _foodontroller;
        private readonly IBasketController _basketController;
        private readonly ICurrencyController _currencyController;
        public MainMenu(IManufacturerController manufacturerController, IClientController clientController, IAddressController addressController,
           IFoodController foodontroller, IBasketController basketController, ICurrencyController currencyController )
        {
            _clientController = clientController;
            _manufacturerController = manufacturerController;
            _addressController = addressController;
            _foodontroller = foodontroller;
            _basketController = basketController;
            _currencyController = currencyController;
        }
        public async Task Start()
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
                    2 => new ClientMenu(this, _clientController, _basketController, _addressController, _manufacturerController, _currencyController),
                    _ => null
                };
                if (_serviceMenu is null)
                    Console.WriteLine("Input value outside the menu ");
            }
           await _serviceMenu.Start();
        }
    }
}
