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
            var log = new DataLogger("log","txt");

            var clients = new DatabaseController<Client>(db, log);
            var manufacturers = new DatabaseController<Manufacturer>(db, log);
            var addresses = new DatabaseController<Address>(db, log);
            var foods = new DatabaseController<Food>(db, log);
            var foodTypes = new DatabaseController<FoodType>(db, log);
            var baskets = new DatabaseController<Basket>(db, log);
            var orders = new DatabaseController<Order>(db, log);

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
