using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Data.Interfaces
{
    public interface IRepository<T>  where T : BaseModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithoutTracking();
        T GetOne(int id);
        void Add(T entity);
        void Add(IList<T> entities);
        void Update(T entity);
        void Update(IList<T> entities);
        void Delete(int id);
        IEnumerable<T> GetSome(Func<T,bool> where);
    }
}
