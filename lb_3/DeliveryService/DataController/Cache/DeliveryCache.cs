using DeliveryService.Abstracts;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DataController.Cache
{
    public class DeliveryCache :  ICache
    {
        public Dictionary<Type, IList> Cache { get; set; }
      
        public DeliveryCache()
        {
            Cache = new Dictionary<Type, IList>();
            InitializeData();
        }

        public void InitializeData()
        {
            Cache.Add(typeof(Manufacturer), new List<Manufacturer>());
            Cache.Add(typeof(Client), new List<Client>());
            Cache.Add(typeof(Address), new List<Address>());
            Cache.Add(typeof(Food), new List<Food>());
            Cache.Add(typeof(FoodType), new List<FoodType>());
            Cache.Add(typeof(Order), new List<Order>());
            Cache.Add(typeof(Basket), new List<Basket>());
        }
    }
}
