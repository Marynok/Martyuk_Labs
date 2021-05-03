using DeliveryService.Controllers;
using DeliveryService.Database;
using DeliveryService.DataController;
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

            var clients = new DatabaseController<Client>(db);
            var manufacturers = new DatabaseController<Manufacturer>(db);
            var addresses = new DatabaseController<Address>(db);
            var foods = new DatabaseController<Food>(db);
            var foodTypes = new DatabaseController<FoodType>(db);
            var baskets = new DatabaseController<Basket>(db);
            var orders = new DatabaseController<Order>(db);

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
