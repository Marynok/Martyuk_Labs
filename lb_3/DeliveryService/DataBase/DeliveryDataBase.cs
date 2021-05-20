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
        private ISerializer _serializer;
        public DeliveryDatabase(ISerializer serializer)
        {
            Database = new Dictionary<Type, IList>();
            _serializer = serializer;
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
            ((List<Manufacturer>)Database[typeof(Manufacturer)]).AddRange(_serializer.DeserializeFromFile<Manufacturer>(typeof(Manufacturer).Name));
            ((List<Client>)Database[typeof(Client)]).AddRange(_serializer.DeserializeFromFile<Client>(typeof(Client).Name));
            ((List<Address>)Database[typeof(Address)]).AddRange(_serializer.DeserializeFromFile<Address>(typeof(Address).Name));
            ((List<Food>)Database[typeof(Food)]).AddRange(_serializer.DeserializeFromFile<Food>(typeof(Food).Name));
            ((List<FoodType>)Database[typeof(FoodType)]).AddRange(_serializer.DeserializeFromFile<FoodType>(typeof(FoodType).Name));
            ((List<Order>)Database[typeof(Order)]).AddRange(_serializer.DeserializeFromFile<Order>(typeof(Order).Name));
            ((List<Basket>)Database[typeof(Basket)]).AddRange(_serializer.DeserializeFromFile<Basket>(typeof(Basket).Name));
        }
        public void SaveData<TModel>() where TModel:Model
        {
            _serializer.SerializeToFile((IList<TModel>)Database[typeof(TModel)], typeof(TModel).Name);
        }
    }
}
