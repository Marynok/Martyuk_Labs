using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Database
{
    public class DeliveryDatabase: IDataBase
    {
        public Dictionary<Type, IList> Database { get; set; }
        private IDataSaver _dataSaver;
        public DeliveryDatabase(IDataSaver dataSaver)
        {
            Database = new Dictionary<Type, IList>();
            _dataSaver = dataSaver;
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

        public void ReadData()
        {
            ((List<Manufacturer>)Database[typeof(Manufacturer)]).AddRange(_dataSaver.ReadFromFile<Manufacturer>(typeof(Manufacturer).Name));
            ((List<Client>)Database[typeof(Client)]).AddRange(_dataSaver.ReadFromFile<Client>(typeof(Client).Name));
            ((List<Address>)Database[typeof(Address)]).AddRange(_dataSaver.ReadFromFile<Address>(typeof(Address).Name));
            ((List<Food>)Database[typeof(Food)]).AddRange(_dataSaver.ReadFromFile<Food>(typeof(Food).Name));
            ((List<FoodType>)Database[typeof(FoodType)]).AddRange(_dataSaver.ReadFromFile<FoodType>(typeof(FoodType).Name));
            ((List<Order>)Database[typeof(Order)]).AddRange(_dataSaver.ReadFromFile<Order>(typeof(Order).Name));
            ((List<Basket>)Database[typeof(Basket)]).AddRange(_dataSaver.ReadFromFile<Basket>(typeof(Basket).Name));
        }

        public void SaveData<TModel>() where TModel:Model
        {
            _dataSaver.SaveToFile((IList<TModel>)Database[typeof(TModel)], typeof(TModel).Name);
        }
    }
}
