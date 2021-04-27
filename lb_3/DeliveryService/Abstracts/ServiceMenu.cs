using DeliveryService.Controllers;
using DeliveryService.DataController;
using DeliveryService.Interfaces;
using DeliveryService.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Abstracts
{
   public abstract class ServiceMenu: IMenu
    {
        private IMenu _mainMenu;
        protected AddressController _addressController;
        protected ManufacturerController _manufacturerController;
        public ServiceMenu(IMenu mainMenu,AddressController addressController, ManufacturerController manufacturerController)
        {
            _addressController = addressController;
            _mainMenu = mainMenu;
            _manufacturerController = manufacturerController;
        }
        public void Start()
        {
            SignIn();
        }
        public void Exit()
        {
            Console.Clear();
            _mainMenu.Start();
        }
        public abstract void SignIn();
        public abstract void Registrate();
        public abstract void PersonalArea();

    }
}
