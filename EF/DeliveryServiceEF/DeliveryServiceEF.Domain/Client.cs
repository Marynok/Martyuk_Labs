using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class Client: Person
    {
        public IList<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName}, Last name: {LastName}, Phone: {PhoneNumber}";
        }

    }
}
