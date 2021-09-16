using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain;
using Microsoft.EntityFrameworkCore;


namespace DeliveryServiceEF.Data.DataWorkers
{
    public class UnitOfWork: IUnitOfWork
    {
        private protected DbContext _context;
        private IFullRepository<Food> _foodRepository;
        private IFullRepository<Manufacturer> _manufacturerRepository;
        private IRepository<FoodType> _foodTypeRepository;
        public IFullRepository<Food> FoodRepository
        { get
            {
                if (_foodRepository == null)
                    _foodRepository = new FoodRepository(_context);
                return _foodRepository;
            }
        }

        public IFullRepository<Manufacturer> ManufacturerRepository
        {
            get
            {
                if (_manufacturerRepository == null)
                    _manufacturerRepository = new ManufacturerRepository(_context);
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
