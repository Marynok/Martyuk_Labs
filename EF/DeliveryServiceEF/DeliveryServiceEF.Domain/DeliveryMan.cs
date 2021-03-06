using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
{
    public class DeliveryMan : Person
    {
        public int CurrentDeliveryId { get; set; }
        public Delivery CurrentDelivery { get; set; }
        public IList<Delivery> Deliveries { get; set; }
    }
}
