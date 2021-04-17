using DeliveryService.models.baseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.models
{
     public class Address: Model
    {
        public Street StreetName { get; set; }
        public HouseNumber HouseNumberName { get; set; }
    }
}
