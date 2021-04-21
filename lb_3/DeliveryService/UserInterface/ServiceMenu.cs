using DeliveryService.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.UserInterface
{
   public abstract class ServiceMenu
   {
        public DeliveryDataBase DeliveryDataBase { get; private set; }
        public MainMenu MainMenu { get; private set; }
        public ServiceMenu(MainMenu mainMenu, DeliveryDataBase deliveryDataBase)
        {
            DeliveryDataBase = deliveryDataBase;
            MainMenu = mainMenu;
        }
        public void Start()
        {
        }
        public void Exit()
        {
            Console.Clear();
            MainMenu.Start(DeliveryDataBase);
        }
        public abstract void SignIn();
        public abstract void Registr();
        public abstract void PersonalArea();

    }
}
