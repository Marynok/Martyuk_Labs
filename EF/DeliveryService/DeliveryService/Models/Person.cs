using System;
using System.Collections.Generic;
using DeliveryService.Models.Base;

namespace DeliveryService.Models
{
     public class Person: BaseModel
     {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
     }
}
