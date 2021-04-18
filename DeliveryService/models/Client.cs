using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Client: Person
    {
        public IList<Order> Orders { get; set; }
    }
}
