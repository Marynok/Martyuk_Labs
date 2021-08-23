using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Data.DataWorkers
{
    public class Repository<T> : IRepository<T>
        where T: BaseModel
    {
        private protected DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetOne(int id)
        {
            return _context.Find<T>(id);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Add(IList<T> entities)
        {
            _context.AddRange(entities);
        }

        public void Update(T entity)
        {
             _context.Update(entity);
        }

        public void Update(IList<T> entities)
        {
            _context.UpdateRange(entities);
        }

        public void Delete(int id)
        {
            var entity = GetOne(id);
            if (entity != null)
                _context.Remove(entity);
        }

        public IEnumerable<T> GetSome(Func<T, bool> where)
        {
            return _context.Set<T>().Where(where);
        }
    }
}
