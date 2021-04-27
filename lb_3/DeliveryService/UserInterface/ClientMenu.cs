using DeliveryService.Abstracts;
using DeliveryService.Controllers;
using DeliveryService.Interfaces;
using DeliveryService.UserInterface.Check;
using System;
using System.Linq;

namespace DeliveryService.UserInterface
{
    public class ClientMenu : ServiceMenu
    {
        private readonly string[] _cabinetMenuItems = new string[] { "Show orders", "Create new order", "Exit" };
        private readonly string[] _orderMenuItems = new string[] { "Add product", "Create order", "Exit" };
        private IClientController _clientController;
        private IBasketController _basketController;
        public ClientMenu(IMenu mainMenu, IClientController clientController, IBasketController basketController,
            IAddressController addressController, IManufacturerController manufacturerController) 
            : base(mainMenu, addressController, manufacturerController)
        {
            _clientController = clientController;
            _basketController = basketController;
        }
        public override void PersonalArea()
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
                        CreateNewOrder();
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
        public override void SignIn()
        {
            _clientController.SearchClient("099502352114");
            _basketController.SetBasket(_clientController.Client);
            PersonalArea();
        }
        public void CreateNewOrder()
        {
            Console.Clear();
             SelectManufacturer();

            var continueCheck = true;
            while (continueCheck)
            {
                Console.Clear();
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
        private void CreateOrder()
        {
            var items = _basketController.GetBasketItems();
            if (items.Any())
            {
                BaseConsoleFunction.WithdrawList(items.ToArray());
                if (BaseConsoleFunction.CheckArea("Want to issue a order ? y/n", "y"))
                {
                    var street = BaseConsoleFunction.GetProperty("Enter street");
                    var houseNumber = BaseConsoleFunction.GetProperty("Enter house number");
                    var address =AddressController.CreateAddress(street, houseNumber);
                    _clientController.CreateOrder(address,_basketController.Basket);
                    _basketController.ClearBasket();
                    Console.WriteLine("Order was created!");
                    Console.ReadLine();
                }
            }
            else
                BaseConsoleFunction.GetProperty("Your basket is empty. Press enter to continue ");
        }

        public void ShowOrders()
        {
            Console.Clear();
            BaseConsoleFunction.WithdrawList(_clientController.Client.Orders.ToArray());
            Console.ReadLine();
        }
        public void ShowMenu()
        {
            var foods  = (ManufacturerController.GetFoods());
            if (foods.Any())
                BaseConsoleFunction.WithdrawList(foods.ToArray());
            else
                Console.WriteLine("This manufacturer have not foods yet");
        }

        public void SelectManufacturer()
        {
            BaseConsoleFunction.WithdrawList(ManufacturerController.GetAll().ToArray());
            Console.WriteLine("Select number of manufacturer");
            while (true)
            {
                var id = Checker.GetPropertyInt(Console.ReadLine());
                if (ManufacturerController.SearchManufacturer(id) != null)
                    break;
                else
                    Console.WriteLine($"{id} manufacturer does not exist");
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
