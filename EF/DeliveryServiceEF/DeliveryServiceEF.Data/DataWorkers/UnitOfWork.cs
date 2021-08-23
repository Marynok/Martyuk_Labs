using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain;
using Microsoft.EntityFrameworkCore;


namespace DeliveryServiceEF.Data.DataWorkers
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
            //_context.Database.Migrate();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
