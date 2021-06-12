using DeliveryService.Abstracts;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DataController.Cashe
{
    public class ThreadSafeCache :  ICache
    {
        public Dictionary<Type, Object> Locks { get;}
        public Dictionary<Type, IList> Cache { get; set; }
      
        public ThreadSafeCache()
        {
            Locks = new Dictionary<Type, Object>();
            Cache = new Dictionary<Type, IList>();
            InitializeData();
            InitializeLock();
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

        public void InitializeLock()
        {
            Locks.Add(typeof(Manufacturer), new object());
            Locks.Add(typeof(Client), new object());
            Locks.Add(typeof(Address), new object());
            Locks.Add(typeof(Food), new object());
            Locks.Add(typeof(FoodType), new object());
            Locks.Add(typeof(Order), new object());
            Locks.Add(typeof(Basket), new object());
        }

        public IList<TModel> GetList<TModel>()
        {
            var locker = Locks[typeof(TModel)];
            lock (locker)
            {
                return (IList<TModel>)Cache[typeof(TModel)];
            }
        }
    }
}
