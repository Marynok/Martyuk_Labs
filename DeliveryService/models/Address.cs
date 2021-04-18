using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
     public class Address: Model
    {
        public string StreetName { get; set; }
        public string HouseNumberName { get; set; }
    }
}
