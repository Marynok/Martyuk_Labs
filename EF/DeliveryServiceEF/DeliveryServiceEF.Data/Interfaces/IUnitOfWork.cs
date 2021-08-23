using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Food> FoodRepository { get; }
        public IRepository<Manufacturer> ManufacturerRepository { get; }
        public IRepository<FoodType> FoodTypeRepository { get; }
        void Save();
    }
}
