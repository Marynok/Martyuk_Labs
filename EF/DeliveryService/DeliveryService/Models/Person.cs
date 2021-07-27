using System;
using System.Collections.Generic;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
     public class Person
     {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public Person()
        {}

        public Person(string name, string secondName, string phone) 
        {
            Name = name;
            SecondName = secondName;
            Phone = phone;
        }

        public Person(int id, string name, string secondName, string phone) 
        {
            Name = name;
            SecondName = secondName;
            Phone = phone;
        }
     }
}
