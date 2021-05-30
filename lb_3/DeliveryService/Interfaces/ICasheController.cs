using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ICasheController
    {
        TModel Search<TModel>(Func<TModel, bool> func);

         void SetToCashe<TModel>(TModel model, IList<TModel> models) where TModel : Model;

        void RemoveFromCashe<TModel>(Action<TModel, IList<TModel>> action, TModel model) where TModel : Model;

        void SetToCasheInThread<TModel>(Action<Action<TModel, IList<TModel>>, TModel> action,Action<TModel, IList<TModel>> secAction,TModel model) where TModel : Model;
    }
}
