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
        public DeliveryDataBase()
        {
            Manufacturers = new List<Manufacturer>();
            Clients = new List<Client>();
            Addresses = new List<Address>();
            Foods = new List<Food>();
            FoodTypes = new List<FoodType>();
            Orders = new List<Order>();
        }
        public Manufacturer SearchManufacturer(string name)
        {
            return Manufacturers.FirstOrDefault(m => m.Name == name);
        }
        public Client SearchClient(int phone)
        {
            return Clients.FirstOrDefault(c => c.PhoneNumber == phone);
        }
        public Address SearcAddress(string street, string houseNumber)
        {
            return Addresses.FirstOrDefault(a => a.StreetName == street && a.HouseNumberName == houseNumber);
        }
        public FoodType SearcFoodType(string name)
        {
            return FoodTypes.FirstOrDefault(f => f.Name == name);
        }
        public Manufacturer SearchManufacturerById(int id)
        {
            return (Manufacturer)SearchModelById(Manufacturers.ToArray(), id);
        }
        public Model SearchModelById(Model[] models, int id)
        {
            return models.FirstOrDefault(m => m.Id == id);
        }

        public Address CreateAddress(string street, string houseNumber)
        {
            var address = SearcAddress(street, houseNumber);
            if (address is null)
            {
                address = new Address(getId(Addresses.ToArray()), street, houseNumber);
                Addresses.Add(address);
            }
            return address;
        }

        public Manufacturer CreateManufacturer(string name, string street, string houseNumber, string description)
        {
            var address = CreateAddress(street, houseNumber);
            var manufacturer = new Manufacturer(getId(Manufacturers.ToArray()), name, address, description);
            Manufacturers.Add(manufacturer);
            return manufacturer;
        }

        public Client CreateClient(string firstName, string lastName, int phoneNumber)
        {
            var client = new Client(getId(Clients.ToArray()), firstName, lastName, phoneNumber);
            Clients.Add(client);
            return client;
        }

        public Food CreateFood(string name, decimal price, float weight, string type, Manufacturer manufacturer)
        {
            var foodType = SearcFoodType(type);
            if (foodType is null)
            {
                foodType = new FoodType(getId(FoodTypes.ToArray()), type);
                FoodTypes.Add(foodType);
            }
            var food = new Food(getId(Foods.ToArray()), name, price, weight, foodType);
            manufacturer.Foods.Add(food);
            Foods.Add(food);
            return food;
        }

        public void CreateOrder(string street, string houseNumber, Client client, IList<OrderFoodData> orderFoodDatas)
        {
            var address = CreateAddress(street, houseNumber);
            var order = new Order(getId(Orders.ToArray()), address);
            Orders.Add(order);
            client.AddOreder(order);
            order.AddFoods(orderFoodDatas);
        }
        public OrderFoodData CreateFoodItem(int id, int count)
        {
            var food = (Food)SearchModelById(Foods.ToArray(), id);
            if (food is null)
                return null;
            else
            return new OrderFoodData(count, food);
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
