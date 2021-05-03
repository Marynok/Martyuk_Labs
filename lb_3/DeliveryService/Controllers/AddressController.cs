using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controllers
{
    public class AddressController: IAddressController
    {
        private readonly IDatabaseController<Address> _addresses;
        public AddressController(IDatabaseController<Address> addresses)
        {
            _addresses = addresses;
        }
        public Address SearchAddress(string street, string houseNumber)
        {
            return _addresses.Search(a => a.StreetName == street && a.HouseNumberName == houseNumber);
        }

        public Address CreateAddress(string street, string houseNumber)
        {
            var address = SearchAddress(street, houseNumber);
            if (address is null)
            {
                address = new Address(street, houseNumber);
                _addresses.AddModel(address);
            }
            return address;
        }

    }
}
