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
    class ThreadSafeDataCashe : Repository, ICashe
    {
        public Dictionary<Type, Object> Locks { get; set; }
        public ThreadSafeDataCashe()
        {
            Locks = new Dictionary<Type, Object>();
            InitializeData();
            InitializeLock();
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
                return (IList<TModel>)Database[typeof(TModel)];
            }
        }
    }
}
