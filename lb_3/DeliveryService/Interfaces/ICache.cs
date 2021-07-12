using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ICache
    {
        Dictionary<Type, IList> Cache { get; set; }
        void InitializeData();
    }
}
