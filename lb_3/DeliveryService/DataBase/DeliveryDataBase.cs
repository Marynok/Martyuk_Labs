using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using DeliveryService.Models.BaseModel;
using DeliveryService.Abstracts;

namespace DeliveryService.Database
{
    public class DeliveryDatabase:Repository, IDataBase
    {
        private ISerializer _serializer;
        public DeliveryDatabase(ISerializer serializer)
        {
            _serializer = serializer;
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
