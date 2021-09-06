using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Data.DataWorkers
{
    public class FoodRepository : Repository<Food>, IFullRepository<Food>
    {
        public FoodRepository(DbContext context) : base(context) { }

        public IEnumerable<Food> GetAllWithObjects()
        {
            var foods = _context.Set<Food>().AsNoTracking()
                 .Include(f => f.OrderFoodDatas)
                 .Include(f => f.Manufacturer)
                 .Include(f => f.Type);

            return foods;
        }

        public Food GetOneWithObjects(int id)
        {
            var food = _context.Set<Food>().AsNoTracking().Where(f => f.Id == id)
                .Include(f => f.OrderFoodDatas)
                 .Include(f => f.Manufacturer)
                 .Include(f => f.Type)
                 .FirstOrDefault();

            return food;
        }
    }
}
