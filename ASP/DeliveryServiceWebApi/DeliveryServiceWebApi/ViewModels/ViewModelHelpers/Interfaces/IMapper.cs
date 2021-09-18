using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.ViewModels.ViewModelHelpers.Interfaces
{
    public interface IMapper <Type,ViewType>
    {
        Type Map(ViewType modelView);
        ViewType Map(Type model);
    }
}
