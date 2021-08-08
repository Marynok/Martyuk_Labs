using System.Collections.Generic;

namespace DeliveryService.Models
{
    public class DeliveryMan : Person
    {
        public Delivery CurrentDelivery { get; set; }
    }
}
