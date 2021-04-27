using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IAddressController
    {
        Address SearchAddress(string street, string houseNumber);
        Address CreateAddress(string street, string houseNumber); 
    }
}
