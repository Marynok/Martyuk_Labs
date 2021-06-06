using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DeliveryService.Models.BaseModel;

namespace DeliveryService.Models
{
     public class Person: Model
     {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [JsonConstructor]
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
