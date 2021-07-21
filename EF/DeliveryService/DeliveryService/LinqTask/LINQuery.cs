using DeliveryService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.LinqTask
{
   public class LINQuery
    {
        public IList<Food> Foods { get; set; }
        public IList<FoodType> FoodTypes { get; set; }
        public IList<Manufacturer> Manufacturers { get; set; }

        public LINQuery(IList<Manufacturer> manufacturers, IList<FoodType> foodTypes, IList<Food> foods)
        {
            Foods = foods;
            FoodTypes = foodTypes;
            Manufacturers = manufacturers;
        }

        public IEnumerable GetSortFoods()
        {
            return (Foods?.OrderBy(f => f.Name)).ToList();
        }

        public IEnumerable GetFoodsManufacturersName()
        {
            return (Manufacturers?.SelectMany(m => m.Foods,
                            (m, f) => new { Manufacturer = m.Name, Food = f.Name })).ToList();
        }

        public IEnumerable GetCountFoodInTypes()
        {
            return Foods?.GroupBy(f => f.Type.Name)
                         .Select(t => new { Type = t.Key, CountFoods = t.Count() }).ToList();
        }

        public IEnumerable GetCountFoodInManufacturers()
        {
            return Manufacturers?.OrderByDescending(m => m.Foods.Count())
                                 .Select(m => new { Manufacturer = m.Name, CountFoods = m.Foods.Count() }).ToList();
        }

        public IEnumerable GetCommonFoodForTwoManufacturers(Manufacturer firstManufacturer, Manufacturer secondManufacturer)
        {
            return (firstManufacturer.Foods).Intersect(secondManufacturer.Foods, new FoodComparer()).ToList();
        }

        public IEnumerable GetUniqueFood(Manufacturer firstManufacturer, Manufacturer secondManufacturer)
        {
            return ((firstManufacturer.Foods).Except(secondManufacturer.Foods, new FoodComparer()))
                                             .Select(f => new { Manufacturer = firstManufacturer, Food = f }).ToList();
        }

        public void PrintList(IEnumerable list)
        {
            foreach (var l in list)
                Console.WriteLine(l);
            Console.WriteLine();
        }
    }
}
