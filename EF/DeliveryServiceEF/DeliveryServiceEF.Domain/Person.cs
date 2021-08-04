using DeliveryServiceEF.Domain.BaseModel;
using System;
using System.Collections.Generic;


namespace DeliveryServiceEF.Domain
{
     public class Person: Model
     {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Person() { }

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
