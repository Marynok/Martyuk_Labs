using DeliveryServiceEF.Domain;
using DeliveryServiceEF.UI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.UI.DataWorkers
{
    public class UnitOfWork: IUnitOfWork
    {
        private protected DbContext _context;
        private IRepository<Food> _foodRepository;
        private IRepository<Manufacturer> _manufacturerRepository;
        private IRepository<FoodType> _foodTypeRepository;
        public IRepository<Food> FoodRepository
        { get
            {
                if (_foodRepository == null)
                    _foodRepository = new Repository<Food>(_context);
                return _foodRepository;
            }
        }

        public IRepository<Manufacturer> ManufacturerRepository
        {
            get
            {
                if (_manufacturerRepository == null)
                    _manufacturerRepository = new Repository<Manufacturer>(_context);
                return _manufacturerRepository;
            }
        }

        public IRepository<FoodType> FoodTypeRepository
        {
            get
            {
                if (_foodTypeRepository == null)
                    _foodTypeRepository = new Repository<FoodType>(_context);
                return _foodTypeRepository;
            }
        }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
