using DeliveryService.Models;
using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DataBase
{
    public class DeliveryDataBase
    {
        public IList<Manufacturer> Manufacturers { get ; private set ; }
        public IList<Client> Clients { get; private set; }
        public IList<Food> Foods { get; private set; }
        public IList<Order> Orders { get; private set; }
        public IList<FoodType> FoodTypes { get; private set; }
        public IList<Address> Addresses { get; private set; }
        public IList<Basket> Baskets { get; private set; }
        
        public DeliveryDataBase()
        { }
        public void InitializeData()
        {
            Manufacturers = new List<Manufacturer>();
            Clients = new List<Client>();
            Addresses = new List<Address>();
            Foods = new List<Food>();
            FoodTypes = new List<FoodType>();
            Orders = new List<Order>();
            Baskets = new List<Basket>();
        }
    }
}
