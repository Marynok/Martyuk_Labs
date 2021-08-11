using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;


namespace DeliveryServiceEF.Domain
{
     public class Person: BaseModel
     {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
     }
}
