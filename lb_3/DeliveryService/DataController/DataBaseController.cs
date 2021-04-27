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
        private IDataBase _database;
        private IList<TModel> _models;
        public DatabaseController(IDataBase database)
        {
            _database = database;
            _models = (IList<TModel>)_database.Database[typeof(TModel)];
        }

        public void AddModel(TModel model)
        {
            if (model != null)
            {
                model.Id = GetId();
                _models.Add(model);
            }
        }

        public TModel Search(Func<TModel, bool> func)
        {
            return _models.SingleOrDefault(func);
        }
        
        public IEnumerable<TModel> GetAll()
        {
            return _models;
        }
        private int GetId()
        {
            if (_models.Count == 0)
                return 1;
            else
                return _models.Last().Id + 1;
        }
    }
}
