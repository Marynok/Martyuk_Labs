using DeliveryService.Controllers;
using DeliveryService.Database;
using DeliveryService.DataController;
using DeliveryService.DataController.Logger;
using DeliveryService.Models;
using DeliveryService.DataSaver;
using DeliveryService.UserInterface;
using System.Threading.Tasks;

namespace DeliveryService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dataSaver = new DeliveryDataSaver("datas");
            var db = new DeliveryDatabase(dataSaver);
            db.InitializeData();
            db.ReadData();

            var logger = new DeliveryLogger("log","txt");

            var clients = new DatabaseController<Client>(db, logger);
            var manufacturers = new DatabaseController<Manufacturer>(db, logger);
            var addresses = new DatabaseController<Address>(db, logger);
            var foods = new DatabaseController<Food>(db, logger);
            var foodTypes = new DatabaseController<FoodType>(db, logger);
            var baskets = new DatabaseController<Basket>(db, logger);
            var orders = new DatabaseController<Order>(db, logger);
            var currencyController = new CurrencyController();

            var clientController = new ClientController(clients, orders);
            var manufacturerController = new ManufacturerController(manufacturers);
            var addressController = new AddressController(addresses);
            var foodController = new FoodController(foods, foodTypes);
            var basketController = new BasketController(baskets, foods);

            clientController.CreateClient("Alla", "Dernova", "099502352114");
            manufacturerController.CreateManufacturer("MacMod", addressController.CreateAddress("Streey45", "45A"), "");

            var mainMenu = new MainMenu(manufacturerController, clientController, addressController, foodController, basketController, currencyController);

            await mainMenu.Start();
        }
    }
}
