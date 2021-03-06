using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain
{
    public class Delivery: BaseModel
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DeliveryManId { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal Price { get; set; }
    }
}
