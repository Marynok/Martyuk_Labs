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
        public IFullRepository<Food> FoodRepository { get; }
        public IFullRepository<Manufacturer> ManufacturerRepository { get; }
        public IRepository<FoodType> FoodTypeRepository { get; }
        void Save();
    }
}
