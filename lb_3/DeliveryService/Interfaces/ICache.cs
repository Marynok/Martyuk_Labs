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
        Dictionary<Type, Object> Locks { get;}
        void InitializeData();
        void InitializeLock();
        IList<TModel> GetList<TModel>();
    }
}
