using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;

namespace DeliveryService.Interfaces
{
    public interface IDatabaseController<TModel> where TModel: Model
    {
        void AddModel(TModel model);
        void Delete(TModel model);
        void Update(TModel model, TModel newModel);
        TModel Search(Func<TModel, bool> func);
        IEnumerable<TModel> GetAll();
       
    }
}
