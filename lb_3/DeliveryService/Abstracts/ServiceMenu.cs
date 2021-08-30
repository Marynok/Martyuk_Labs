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
        private readonly IMenu _mainMenu;
        private readonly IAddressController _addressController;
        private readonly IManufacturerController _manufacturerController;
        protected IAddressController AddressController { get => _addressController; }
        protected IManufacturerController ManufacturerController { get => _manufacturerController; }

        public ServiceMenu(IMenu mainMenu,IAddressController addressController, IManufacturerController manufacturerController)
        {
            _addressController = addressController;
            _mainMenu = mainMenu;
            _manufacturerController = manufacturerController;
        }
        public async Task Start()
        {
            await SignIn();
        }
      
        public async Task Exit()
        {
            Console.Clear();
            await _mainMenu.Start();
        }
        public abstract Task SignIn();
        public abstract void Registrate();

    }
}
