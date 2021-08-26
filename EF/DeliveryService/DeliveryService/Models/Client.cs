using Dapper.Contrib.Extensions;
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
 
        public override string ToString()
        {
            return $"Id {ClientId} Name: {Name}, Last name: {SecondName}, Phone: {Phone}";
        }

    }
}
