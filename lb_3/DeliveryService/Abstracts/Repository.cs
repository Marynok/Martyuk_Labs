using DeliveryService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Abstracts
{
    public abstract class Repository
    {
        public Dictionary<Type, IList> Database { get; set; }
        public Repository()
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
