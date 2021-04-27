using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections;
using System.Collections.Generic;


namespace DeliveryService.Database
{
    public class DeliveryDatabase: IDataBase
    {
        public Dictionary<Type, IList> Database { get; set; }

        public DeliveryDatabase()
        {
            Database = new Dictionary<Type, IList>();
        }
        public void InitializeData()
        {
            Database.Add(typeof(Manufacturer), new List<Manufacturer>());
            Database.Add(typeof(Client), new List<Client>());
            Database.Add(typeof(Address), new List<Address>());
            Database.Add(typeof(Food), new List<Food>());
            Database.Add(typeof(FoodType), new List<FoodType>());
            Database.Add(typeof(Order), new List<Order>());
            Database.Add(typeof(Basket), new List<Basket>());
        }
    }
}
