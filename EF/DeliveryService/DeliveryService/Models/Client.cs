using Dapper.Contrib.Extensions;
using DeliveryService.Models.BaseModel;
using System.Collections.Generic;


namespace DeliveryService.Models
{
    public class Client: Person
    {
        [Key]
        public int ClientId { get; set; }
        public IList<Order> Orders { get; set; }
        public Client()
        {}
 
        public Client( string firstName, string lastName, string phoneNumber) : base(firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }

        public Client(int clientId, string name, string secomdName, string phone) : base(name, secomdName, phone)
        {
            ClientId = clientId;
            Orders = new List<Order>();
        }

        public override string ToString()
        {
            return $"Id {ClientId} Name: {Name}, Last name: {SecondName}, Phone: {Phone}";
        }

    }
}
