using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    class DeliveryMan: Person
    {
        public Order CurrentOrder { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
