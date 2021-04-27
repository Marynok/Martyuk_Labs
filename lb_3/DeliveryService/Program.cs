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

            var client = new DatabaseController<Client>(db);
            var manufacturer = new DatabaseController<Manufacturer>(db);
            var address = new DatabaseController<Address>(db);
            var food = new DatabaseController<Food>(db);
            var foodTypes = new DatabaseController<FoodType>(db);
            var basket = new DatabaseController<Basket>(db);
            var order = new DatabaseController<Order>(db);

            var clientControllr = new ClientController(client, order);
            var manufacturerControllr = new ManufacturerController(manufacturer);
            var addressController = new AddressController(address);
            var foodControllr = new FoodController(food, foodTypes);
            var basketControllr = new BasketController(basket, food);

            clientControllr.CreateClient("Alla", "Dernova", "099502352114");
            manufacturerControllr.CreateManufacturer("MacMod", addressController.CreateAddress("Streey45", "45A"), "");

            var mainMenu = new MainMenu(manufacturerControllr, clientControllr, addressController, foodControllr, basketControllr);

            mainMenu.Start();
        }
    }
}
