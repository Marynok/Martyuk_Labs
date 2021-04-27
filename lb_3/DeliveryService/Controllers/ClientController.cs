using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class ClientController
    {
        public Client Client;
        public readonly IDatabaseController<Client> Clients;
        public readonly IDatabaseController<Order> Orders;
        public ClientController(IDatabaseController<Client> clients, IDatabaseController<Order> orders)
        {
            Clients = clients;
            Orders = orders;
        }
        public Client CreateClient(string name, string lastName, string phoneNumber)
        {
            Client = Clients.Search(c => c.PhoneNumber == phoneNumber);
            if (Client is null)
            {
                Client = new Client(name, lastName, phoneNumber);
                Clients.AddModel(Client);
            }
            else
                Client = null;
            return Client;
        }
        public Client SearchClient(string phoneNumber)
        {
            Client = Clients.Search(c => c.PhoneNumber == phoneNumber);
            return Client;
        }
        public bool CreateOrder(Address address, Basket basket)
        {
            if (basket.SelectedItems.Count != 0)
            {
                var order = new Order(address);
                foreach (var i in basket.SelectedItems)
                    order.Foods.Add(i);
                Orders.AddModel(order);
                Client.Orders.Add(order);
                return true;
            }
            else
                return false;
        }
    }
}


