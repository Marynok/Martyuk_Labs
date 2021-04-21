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
    public class ClientMenu : ServiceMenu
    {
        readonly string[] cabinetMenuItems = new string[] { "Show orders", "Create new order", "Exit" };
        readonly string[] orderMenuItems = new string[] { "Add product", "Create order", "Exit" };
        private IList<OrderFoodData> orderFoodDatas { get; set; }
        private Client _client;
        public ClientMenu(MainMenu mainMenu, DeliveryDataBase deliveryDataBase) : base(mainMenu, deliveryDataBase)
        {
            _client = deliveryDataBase.SearchClient(503252114); 
            orderFoodDatas = new List<OrderFoodData>();
        }
        public override void PersonalArea()
        {
            var checkMenu = true;
            while (checkMenu)
            {
                Console.Clear();
                Console.WriteLine($"{_client.FirstName} {_client.LastName}");

                BaseConsoleFunction.WithdrawList(cabinetMenuItems);

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
        public override void Registr()
        {}
        public override void SignIn()
        {}
        public void CreateNewOrder()
        {
            Console.Clear();
            var manufacturerId = SelectManufacturer();

            var continueCheck = true;
            while (continueCheck)
            {
                Console.Clear();
                BaseConsoleFunction.WithdrawList(orderMenuItems);
                BaseConsoleFunction.ConsoleDelimiter();
                ShowMenu(manufacturerId);

                var checkItem = Checker.GetPropertyInt(Console.ReadLine());
                switch (checkItem)
                {
                    case 1:
                        addProduct();
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
            if (orderFoodDatas.Count != 0)
            {
                BaseConsoleFunction.WithdrawList(orderFoodDatas.ToArray());
                if (BaseConsoleFunction.CheckAreae("Want to issue a order ? y/n", "y"))
                {
                    var street = BaseConsoleFunction.GetProperty("Enter street");
                    var houseNumber = BaseConsoleFunction.GetProperty("Enter house number");
                    base.DeliveryDataBase.CreateOrder(street, houseNumber, _client, orderFoodDatas);
                    orderFoodDatas.Clear();
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
            BaseConsoleFunction.WithdrawList(_client.Orders.ToArray());
            Console.ReadLine();
        }
        public void ShowMenu(int manufacturerId)
        {
            var foods  = (base.DeliveryDataBase.SearchManufacturerById(manufacturerId).Foods).ToArray();
            if (foods.Length != 0)
                BaseConsoleFunction.WithdrawList((base.DeliveryDataBase.SearchManufacturerById(manufacturerId).Foods).ToArray());
            else
                Console.WriteLine("This manufacturer have not foods yet");
        }

        public int SelectManufacturer()
        {
            BaseConsoleFunction.WithdrawList(base.DeliveryDataBase.Manufacturers.ToArray());
            Console.WriteLine("Select number of manufacturer");
            return Convert.ToInt32(Console.ReadLine());
        }

        private void addProduct()
        {
            var id = Checker.GetPropertyInt(BaseConsoleFunction.GetProperty("Enter product number"));
            var count = Checker.GetPropertyInt(BaseConsoleFunction.GetProperty("Enter count"));
            var itemFood = base.DeliveryDataBase.CreateFoodItem(id, count);
            if (itemFood is null)
                BaseConsoleFunction.GetProperty("This product does not exist");

            else {
                orderFoodDatas.Add(itemFood);
                BaseConsoleFunction.GetProperty($"{itemFood} was add to basket");
            }
                
        }

    }
}
