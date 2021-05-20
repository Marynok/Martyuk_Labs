using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DeliveryService.Models
{
    public class Client: Person
    {
        public IList<Order> Orders { get; set; }
        [JsonConstructor]
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
