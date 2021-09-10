using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Data.Interfaces
{
    public interface IFullRepository<T> : IRepository<T>
        where T : BaseModel
    {
        IEnumerable<T> GetAllWithObjects();
        T GetOneWithObjects(int id);
    }
}
