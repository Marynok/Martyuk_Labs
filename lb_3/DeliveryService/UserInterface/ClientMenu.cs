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
    public class ClientMenu : ServiceMenu
    {
        private readonly string[] _cabinetMenuItems = new string[] { "Show orders", "Create new order", "Exit" };
        private readonly string[] _orderMenuItems = new string[] { "Add product", "Create order", "Exit" };
        private readonly IClientController _clientController;
        private readonly IBasketController _basketController;
        private readonly ICurrencyController _currencyController;
        public ClientMenu(IMenu mainMenu, IClientController clientController, IBasketController basketController,
            IAddressController addressController, IManufacturerService manufacturerService, ICurrencyController currencyController) 
            : base(mainMenu, addressController, manufacturerService)
        {
            _clientController = clientController;
            _basketController = basketController;
            _currencyController = currencyController;
        }
        public async Task PersonalArea()
        {
            var checkMenu = true;
            while (checkMenu)
            {
                Console.Clear();
                Console.WriteLine($"{_clientController.Client.FirstName} {_clientController.Client.LastName}");

                BaseConsoleFunction.WithdrawList(_cabinetMenuItems);

                var checkItem = Checker.GetPropertyInt(Console.ReadLine());
                switch (checkItem)
                {
                    case 1:
                        ShowOrders();
                        break;
                    case 2:
                        await CreateNewOrder();
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
        public override void Registrate()
        {}
        public override async Task SignIn()
        {
            _clientController.SearchClient("099502352114");
            _basketController.SetBasket(_clientController.Client);
            await PersonalArea();
        }
        public async Task  CreateNewOrder()
        {
            Console.Clear();
            if (SelectManufacturer())
            {
                var continueCheck = true;
                while (continueCheck)
                {
                    Console.Clear();
                    await ShowOrderPrice();
                    BaseConsoleFunction.ConsoleDelimiter();
                    BaseConsoleFunction.WithdrawList(_orderMenuItems);
                    BaseConsoleFunction.ConsoleDelimiter();
                    ShowMenu();

                    var checkItem = Checker.GetPropertyInt(Console.ReadLine());
                    switch (checkItem)
                    {
                        case 1:
                            AddProduct();
                            break;
                        case 2:
                            CreateOrder();
                            break;
                        case 3:
                            continueCheck = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect data");
                            break;
                    }
                }
            }
        }
        private void CreateOrder()
        {
            var items = _basketController.GetBasketItems();
            if (items.Any())
            {
                BaseConsoleFunction.WithdrawList(items.ToArray());
                if (BaseConsoleFunction.CheckArea("Want to issue a order ? y/n", "y"))
                {
                    var phoneNumber = Checker.GetPropertyPhoneNumber(BaseConsoleFunction.GetProperty("Enter phone"));
                    var street = Checker.GetPropertyStreet(BaseConsoleFunction.GetProperty("Enter street"));
                    var houseNumber = Checker.GetPropertyHome(BaseConsoleFunction.GetProperty("Enter house number"));
                    var address =AddressController.CreateAddress(street, houseNumber);
                    _clientController.CreateOrder(phoneNumber, address, _basketController.Basket);
                    _basketController.ClearBasket();
                    Console.WriteLine("Order was created!");
                    Console.ReadLine();
                }
            }
            else
                BaseConsoleFunction.GetProperty("Your basket is empty. Press enter to continue ");
        }

        public async Task  ShowOrderPrice()
        {
            var searchCurrency = "EUR";
            var baseCurrency = "UAH";
            var totalPrice = _basketController.GetTotalPrice();
            Console.WriteLine($"Finaly price in {baseCurrency} {totalPrice}");
            Console.WriteLine();
            var currency = await _currencyController.GetExchangeRate(searchCurrency);
            if (currency != 0)
                BaseConsoleFunction.ConsoleWriteOnPosition(0, 1, $"Finaly price in {searchCurrency} {totalPrice / currency}");
        }

        public void ShowOrders()
        {
            Console.Clear();
            BaseConsoleFunction.WithdrawList(_clientController.Client.Orders.ToArray());
            Console.ReadLine();
        }
        public void ShowMenu()
        {
            var foods  = (manufacturerService.GetFoods());
            if (foods.Any())
                BaseConsoleFunction.WithdrawList(foods.ToArray());
            else
                Console.WriteLine("This manufacturer have not foods yet");
        }

        public bool SelectManufacturer()
        {
            if (manufacturerService.GetAll().Any())
            {
                BaseConsoleFunction.WithdrawList(manufacturerService.GetAll().ToArray());
                Console.WriteLine("Select number of manufacturer");
                while (true)
                {
                    var id = Checker.GetPropertyInt(Console.ReadLine());
                    if (manufacturerService.SearchManufacturer(id) != null)
                        break;
                    else
                        Console.WriteLine($"{id} manufacturer does not exist");
                }
                return true;
            }
            else
            {
                BaseConsoleFunction.GetProperty("Manufacturers not yet established");
                return false;
            }
        }

        private void AddProduct()
        {
            var id = Checker.GetPropertyInt(BaseConsoleFunction.GetProperty("Enter product number"));
            var count = Checker.GetPropertyInt(BaseConsoleFunction.GetProperty("Enter count"));
            var itemFood = _basketController.AddToBasket(id, count);
            if (itemFood is null)
                BaseConsoleFunction.GetProperty("This product does not exist");
            else 
                BaseConsoleFunction.GetProperty($"{itemFood} was add to basket");
        }
    }
}
