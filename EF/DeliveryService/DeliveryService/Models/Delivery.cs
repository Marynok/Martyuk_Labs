using DeliveryService.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Delivery: BaseModel
    {
        public Order Order { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"";
        }
    }
}
