using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.models
{
    class DeliveryMan: Person
    {
        public Order CurrentOrder { get; set; }
        public List<Order> Orders { get; set; }
    }
}
