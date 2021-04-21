using DeliveryService.DataBase;
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

            deliveryDataBase.CreateClient("Alla", "Dernova", 503252114);
            deliveryDataBase.CreateManufacturer("MacMod", "Hopkin 34", "234A", "We are cool");

            try
            {
                mainMenu.Start(deliveryDataBase);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
}
    }
}
