using DeliveryServiceEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryServiceWebApi.ViewModels.ViewModelHelpers.Interfaces
{
    public interface IFoodMapper: IMapper<Food, FoodModel>
    {
        ManufacturerModel Map(Manufacturer manufacturer);
        FoodTypeModel Map(FoodType foodType);
    }
}
