using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class Client: Person
    {
        public IList<Order> Orders { get; set; }
        public Client() { }
 
        public Client( string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }

        public Client(int id, string firstName, string lastName, string phoneNumber) : base(id, firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }

        public override string ToString()
        {
            return $"Name: {FirstName}, Last name: {LastName}, Phone: {PhoneNumber}";
        }

    }
}
