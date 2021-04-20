using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Client: Person
    {
        public IList<Order> Orders { get; set; }
        public Client(int id, string firstName, string lastName, int phoneNumber) : base(id, firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }
    }
}
