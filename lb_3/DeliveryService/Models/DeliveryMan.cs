using System.Collections.Generic;

namespace DeliveryService.Models
{
    class DeliveryMan : Person
    {
        public Order CurrentOrder { get; set; }
        public IList<Order> Orders { get; set; }
        public DeliveryMan(int id, string firstName, string lastName, string phoneNumber) : base(id, firstName, lastName, phoneNumber)
        {
            Orders = new List<Order>();
        }
    }
}
