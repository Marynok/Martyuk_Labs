using DeliveryService.Interfaces;
using DeliveryServiceEF.Data.Interfaces;
using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Controllers
{
    public class FoodTypeController : IFoodTypeController
    {
        private readonly IRepository<FoodType> _foodTypes;
        private readonly IUnitOfWork _unitOfWork;
        public FoodTypeController(IUnitOfWork unitOfWork)
        {
            _foodTypes = unitOfWork.FoodTypeRepository;
            _unitOfWork = unitOfWork;
        }
        public FoodType CreateFoodType(FoodType foodType)
        {
            if (foodType is null)
            {
                return null;
            }

            _foodTypes.Add(foodType);
            _unitOfWork.Save();

            return foodType;
        }

        public bool DeleteFoodType(int id)
        {
            if (SearchFoodType(id) is null)
            {
                return false;
            }

            _foodTypes.Delete(id);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<FoodType> Get()
        {
            return _foodTypes.GetAll();
        }

        public FoodType SearchFoodType(int id)
        {
            return _foodTypes.GetOne(id);
        }

        public FoodType UpdateFoodType(FoodType foodType)
        {
            if (foodType is null || SearchFoodType(foodType.Id) is null)
            {
                return null;
            }

            _foodTypes.Update(foodType);
            _unitOfWork.Save();

            return foodType;
        }
    }
}
