using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ICacheController
    {
        TModel GetFromCache<TModel>(Func<TModel, bool> filter) where TModel : Model;

         void SetToCache<TModel>(TModel model, IList<TModel> models) where TModel : Model;

        void RemoveFromCache<TModel>(Action<TModel, IList<TModel>> action, TModel model) where TModel : Model;
    }
}
