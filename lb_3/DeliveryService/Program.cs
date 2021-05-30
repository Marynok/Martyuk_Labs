using DeliveryService.Controllers;
using DeliveryService.Database;
using DeliveryService.DataController;
using DeliveryService.DataController.Cashe;
using DeliveryService.DataController.Logger;
using DeliveryService.Models;
using DeliveryService.Serializer;
using DeliveryService.UserInterface;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new DeliveryJsonSerializer("datas");
            var db = new DeliveryDatabase(serializer);
            var cashe = new ThreadSafeDataCache();
            db.InitializeData();
            db.ReadData();
            
            var cashController = new CacheController(cashe);

            var logger = new DataLogger("log","txt");

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
