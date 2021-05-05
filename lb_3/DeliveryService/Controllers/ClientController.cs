using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class ClientController: IClientController
    {
        private Client _client;
        public Client Client { get => _client; }
        private readonly IDatabaseController<Client> _clients;
        private readonly IDatabaseController<Order> _orders;
        public ClientController(IDatabaseController<Client> clients, IDatabaseController<Order> orders)
        {
            _clients = clients;
            _orders = orders;
        }
        public Client CreateClient(string name, string lastName, string phoneNumber)
        {
            _client = _clients.Search(c => c.PhoneNumber == phoneNumber);
            if (_client is null)
            {
                _client = new Client(name, lastName, phoneNumber);
                _clients.AddModel(Client);
            }
            else
                _client = null;
            return Client;
        }
        public Client SearchClient(string phoneNumber)
        {
            _client = _clients.Search(c => c.PhoneNumber == phoneNumber);
            return Client;
        }
        public bool CreateOrder(string phone,Address address, Basket basket)
        {
            if (basket.SelectedItems.Count != 0)
            {
                var order = new Order(phone,address);
                foreach (var i in basket.SelectedItems)
                    order.Foods.Add(i);
                _orders.AddModel(order);
                _client.Orders.Add(order);
                return true;
            }
            else
                return false;
        }
    }
}


