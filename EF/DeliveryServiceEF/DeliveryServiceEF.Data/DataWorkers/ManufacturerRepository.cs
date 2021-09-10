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
    public class ManufacturerRepository : Repository<Manufacturer>, IFullRepository<Manufacturer>
    {
        public ManufacturerRepository(DbContext context) : base(context) { }
        public IEnumerable<Manufacturer> GetAllWithObjects()
        {
            var manufacturers = GetAll();
            manufacturers.Select(manufacturer => FullManufacturer(manufacturer));

            return manufacturers;
        }

        public Manufacturer GetOneWithObjects(int id)
        {
            var manufacturer = GetOne(id);

            return FullManufacturer(manufacturer); 
        }

        private Manufacturer FullManufacturer(Manufacturer manufacturer)
        {
            _context.Entry(manufacturer)
                .Collection(m => m.Foods)
                .Load();

            _context.Entry(manufacturer)
                 .Reference(m => m.Address)
                 .Load();

            return manufacturer;
        }
    }
}
