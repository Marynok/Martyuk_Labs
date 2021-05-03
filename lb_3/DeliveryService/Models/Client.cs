using System.Collections.Generic;

namespace DeliveryService.Models
{
    public class Client: Person
    {
        public IList<Order> Orders { get; set; }
        public Client( string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }
        public Client(int id, string firstName, string lastName, string phoneNumber) : base(id, firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }
        
    }
}
