using DeliveryService.DataController;
using DeliveryService.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Abstracts
{
   public abstract class ServiceMenu
   {
        public DataBaseController DataBaseController { get; private set; }
        public MainMenu MainMenu { get; private set; }
        public ServiceMenu(MainMenu mainMenu, DataBaseController dataBaseController)
        {
            DataBaseController = dataBaseController;
            MainMenu = mainMenu;
        }
        public void Start(){}
        public void Exit()
        {
            Console.Clear();
            MainMenu.Start(DataBaseController);
        }
        public abstract void SignIn();
        public abstract void Registr();
        public abstract void PersonalArea();

    }
}
