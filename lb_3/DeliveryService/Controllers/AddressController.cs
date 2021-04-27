using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class AddressController
    {
        public readonly IDatabaseController<Address> Addresses;
        public AddressController(IDatabaseController<Address> addresses)
        {
            Addresses = addresses;
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
                address = new Address(street, houseNumber);
                Addresses.AddModel(address);
            }
            return address;
        }

    }
}
