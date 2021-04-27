using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Abstracts
{
    public abstract class ServiceController
    {
        public readonly IDatabaseController<Address> Addresses;
        public readonly IDatabaseController<Manufacturer> Manufacturers;
       public ServiceController( IDatabaseController<Address> addresses, IDatabaseController<Manufacturer> manufacturers)
        {
            Addresses = addresses;
            Manufacturers = manufacturers;
        }
        public Address SearchAddress(string street, string houseNumber)
        {
            return Addresses.Search(a => a.StreetName == street && a.HouseNumberName == houseNumber);
        }

        public Address CreateAddress(string street, string houseNumber)
        {
            var address = SearchAddress(street, houseNumber);
            if (address is null)
            {
                address = new Address( street, houseNumber);
                Addresses.AddModel(address);
            }
            return address;
        }

    }
}
 

  
  
