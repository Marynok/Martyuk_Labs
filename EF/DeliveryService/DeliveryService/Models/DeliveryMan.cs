using System.Collections.Generic;

namespace DeliveryService.Models
{
    class DeliveryMan : Person
    {
        public Delivery CurrentDelivery { get; set; }
        
        public DeliveryMan(int id, string firstName, string lastName, string phoneNumber) : base(id, firstName, lastName, phoneNumber)
        { }
    }
}
