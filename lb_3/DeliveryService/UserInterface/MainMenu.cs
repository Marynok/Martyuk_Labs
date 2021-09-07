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
        private readonly IManufacturerService _manufacturerService;
        private readonly IClientController _clientController;
        private readonly IAddressController _addressController;
        private readonly IFoodService _foodontroller;
        private readonly IBasketController _basketController;
        private readonly ICurrencyController _currencyController;
        public MainMenu(IManufacturerService manufacturerService, IClientController clientController, IAddressController addressController,
           IFoodService foodontroller, IBasketController basketController, ICurrencyController currencyController )
        {
            _clientController = clientController;
            _manufacturerService = manufacturerService;
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
                    1 => new ManufacturerMenu(this, new FoodMenu(_foodontroller, _manufacturerService), _manufacturerService, _addressController),
                    2 => new ClientMenu(this, _clientController, _basketController, _addressController, _manufacturerService, _currencyController),
                    _ => null
                };
                if (_serviceMenu is null)
                    Console.WriteLine("Input value outside the menu ");
            }
           await _serviceMenu.Start();
        }
    }
}
