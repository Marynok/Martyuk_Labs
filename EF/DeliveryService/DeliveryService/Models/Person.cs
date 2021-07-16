using System;
using System.Collections.Generic;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
     public class Person: Model
     {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string firstName, string lastName, string phoneNumber) 
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public Person(int id, string firstName, string lastName, string phoneNumber) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
     }
}
