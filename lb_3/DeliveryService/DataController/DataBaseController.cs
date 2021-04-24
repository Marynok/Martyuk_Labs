using DeliveryService.DataBase;
using DeliveryService.Models;
using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DataController
{
    public class DataBaseController
    {
        private DeliveryDataBase _dataBase;
        public DataBaseController(DeliveryDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        public IList<Manufacturer> GetManufacturers()
        {
            return _dataBase.Manufacturers;
        }
        public IList<OrderFoodData> GetBasketItems(Client client)
        {
            var basket = CreateBasket(client);
            return basket.SelectedItems;
        }
        public Manufacturer SearchManufacturer(string name)
        {
            return _dataBase.Manufacturers.FirstOrDefault(m => m.Name == name);
        }
        public Client SearchClient(int phone)
        {
            return _dataBase.Clients.FirstOrDefault(c => c.PhoneNumber == phone);
        }
        public Address SearcAddress(string street, string houseNumber)
        {
            return _dataBase.Addresses.FirstOrDefault(a => a.StreetName == street && a.HouseNumberName == houseNumber);
        }
        public FoodType SearcFoodType(string name)
        {
            return _dataBase.FoodTypes.FirstOrDefault(f => f.Name == name);
        }
        public Manufacturer SearchManufacturerById(int id)
        {
            return (Manufacturer)SearchModelById(_dataBase.Manufacturers.ToArray(), id);
        }
        public Model SearchModelById(Model[] models, int id)
        {
            return models.FirstOrDefault(m => m.Id == id);
        }
        public Basket SearchBasketByClient(Client client)
        {
            return _dataBase.Baskets.FirstOrDefault(b => b.Client == client);
        }

        public Address CreateAddress(string street, string houseNumber)
        {
            var address = SearcAddress(street, houseNumber);
            if (address is null)
            {
                address = new Address(getId(_dataBase.Addresses.ToArray()), street, houseNumber);
                _dataBase.Addresses.Add(address);
            }
            return address;
        }

        public Manufacturer CreateManufacturer(string name, string street, string houseNumber, string description)
        {
            var address = CreateAddress(street, houseNumber);
            var manufacturer = new Manufacturer(getId(_dataBase.Manufacturers.ToArray()), name, address, description);
            _dataBase.Manufacturers.Add(manufacturer);
            return manufacturer;
        }

        public Client CreateClient(string firstName, string lastName, int phoneNumber)
        {
            var client = new Client(getId(_dataBase.Clients.ToArray()), firstName, lastName, phoneNumber);
            _dataBase.Clients.Add(client);
            return client;
        }
        public Basket CreateBasket(Client client)
        {
            var bascet = SearchBasketByClient(client);
            if (bascet is null)
                bascet = new Basket(getId(_dataBase.Baskets.ToArray()), client);
            _dataBase.Baskets.Add(bascet);
            return bascet;
        }

        public Food CreateFood(string name, decimal price, float weight, string type, Manufacturer manufacturer)
        {
            var foodType = SearcFoodType(type);
            if (foodType is null)
            {
                foodType = new FoodType(getId(_dataBase.FoodTypes.ToArray()), type);
                _dataBase.FoodTypes.Add(foodType);
            }
            var food = new Food(getId(_dataBase.Foods.ToArray()), name, price, weight, foodType);
            manufacturer.Foods.Add(food);
            _dataBase.Foods.Add(food);
            return food;
        }

        public void CreateOrder(string street, string houseNumber, Client client, IList<OrderFoodData> orderFoodDatas)
        {
            var address = CreateAddress(street, houseNumber);
            var order = new Order(getId(_dataBase.Orders.ToArray()), address);
            _dataBase.Orders.Add(order);
            client.AddOreder(order);
            order.AddFoods(orderFoodDatas);
        }
        public OrderFoodData CreateFoodItem(int id, int count)
        {
            var food = (Food)SearchModelById(_dataBase.Foods.ToArray(), id);
            if (food is null)
                return null;
            else
                return new OrderFoodData(count, food);
        }
        public void ClearBasket(Client client)
        {
            var bascet = SearchBasketByClient(client);
            if (bascet != null)
                bascet.ClearItems();
        }
        public void AddToBasket(Client client, OrderFoodData foodItem)
        {
            var basket = CreateBasket(client);
            basket.AddItem(foodItem);
        }

        private int getId(Model[] list)
        {
            if (list.Length == 0)
                return 1;
            else
                return list.Last().Id + 1;
        }
    }
}
