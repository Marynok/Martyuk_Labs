using DeliveryService.DataBase;
using DeliveryService.DataController;
using DeliveryService.Models;
using DeliveryService.UserInterface;
using System;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            var deliveryDataBase = new DeliveryDataBase();
            deliveryDataBase.InitializeData();
            var dbController = new DataBaseController(deliveryDataBase);

            dbController.CreateClient("Alla", "Dernova", 503252114);
            dbController.CreateManufacturer("MacMod", "Hopkin 34", "234A", "We are cool");

            mainMenu.Start(dbController);
        }
    }
}
