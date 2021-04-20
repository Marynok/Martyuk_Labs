using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    class DeliveryMan: Person
    {
        public Order CurrentOrder { get; set; }
        public IList<Order> Orders { get; set; }
        public DeliveryMan(int id, string firstName, string lastName, int phoneNumber) : base(id, firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }
    }
}
