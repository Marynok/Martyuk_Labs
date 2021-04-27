using DeliveryService.Interfaces;
using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.DataController
{
    public class DatabaseController<TModel> : IDatabaseController<TModel>
        where TModel : Model
    {
        private readonly IDataBase _database;
        public DatabaseController(IDataBase database)
        {
            _database = database;
        }

        public void AddModel(TModel model)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (model != null)
            {
                model.Id = GetId();
                models.Add(model);
            }
        }

        public TModel Search(Func<TModel, bool> func)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            return models.SingleOrDefault(func);
        }
        
        public IEnumerable<TModel> GetAll()
        {
            return (IList<TModel>)_database.Database[typeof(TModel)];
        }
        private int GetId()
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (models.Count == 0)
                return 1;
            else
                return models.Last().Id + 1;
        }
    }
}
