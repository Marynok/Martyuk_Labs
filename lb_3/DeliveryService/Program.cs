using DeliveryService.Controllers;
using DeliveryService.Database;
using DeliveryService.DataController;
using DeliveryService.DataController.Logger;
using DeliveryService.Models;
using DeliveryService.UserInterface;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DeliveryDatabase();
            db.InitializeData();
            var logger = new DataLogger("log","txt");

            var clients = new DatabaseController<Client>(db, logger);
            var manufacturers = new DatabaseController<Manufacturer>(db, logger);
            var addresses = new DatabaseController<Address>(db, logger);
            var foods = new DatabaseController<Food>(db, logger);
            var foodTypes = new DatabaseController<FoodType>(db, logger);
            var baskets = new DatabaseController<Basket>(db, logger);
            var orders = new DatabaseController<Order>(db, logger);

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
