using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IClientController
    {
        Client Client { get; }
        Client CreateClient(string name, string lastName, string phoneNumber);
        Client SearchClient(string phoneNumber);
        bool CreateOrder(string phone,Address address, Basket basket);
    }
}
