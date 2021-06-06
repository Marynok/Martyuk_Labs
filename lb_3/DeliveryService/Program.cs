using DeliveryService.Controllers;
using DeliveryService.Database;
using DeliveryService.DataController;
using DeliveryService.DataController.Cashe;
using DeliveryService.DataController.Logger;
using DeliveryService.Models;
using DeliveryService.DataSaver;
using DeliveryService.UserInterface;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSaver = new DeliveryDataSaver("datas");
            var db = new DeliveryDatabase(dataSaver);
            db.InitializeData();
            db.ReadData();

            var cashe = new ThreadSafeCache();
            var cashController = new CacheController(cashe);

            var logger = new DeliveryLogger("log","txt");

            var clients = new DatabaseController<Client>(db, logger, cashController);
            var manufacturers = new DatabaseController<Manufacturer>(db, logger, cashController);
            var addresses = new DatabaseController<Address>(db, logger, cashController);
            var foods = new DatabaseController<Food>(db, logger, cashController);
            var foodTypes = new DatabaseController<FoodType>(db, logger, cashController);
            var baskets = new DatabaseController<Basket>(db, logger, cashController);
            var orders = new DatabaseController<Order>(db, logger, cashController);

            var clientController = new ClientController(clients, orders);
            var manufacturerController = new ManufacturerController(manufacturers);
            var addressController = new AddressController(addresses);
            var foodController = new FoodController(foods, foodTypes);
            var basketController = new BasketController(baskets, foods);

            clientController.CreateClient("Alla", "Dernova", "099502352114");
            manufacturerController.CreateManufacturer("MacMod", addressController.CreateAddress("Streey45", "45A"), "");

            var mainMenu = new MainMenu(manufacturerController, clientController, addressController, foodController, basketController);

            mainMenu.Start();
        }
    }
}
