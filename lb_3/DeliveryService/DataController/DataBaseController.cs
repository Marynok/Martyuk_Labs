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
        private readonly IDataLogger _logger;
        public DatabaseController(IDataBase database, IDataLogger logger)
        {
            _database = database;
            _logger = logger;
        }

        public void AddModel(TModel model)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (model != null)
            {
                model.Id = GetId();
                models.Add(model);
                _logger.SaveChanges(DataMessage.Create(model));
            }
        }
        public void Delete(TModel model)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (model != null)
            {
                if (models.Remove(model)) 
                    _logger.SaveChanges(DataMessage.Delete(model));
            }
        }
        public void Update(TModel model, TModel newModel)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (newModel != null)
            {
                var index = models.IndexOf(model);
                if (index > -1)
                {
                    models.RemoveAt(index);
                    models.Insert(index, newModel);
                    _logger.SaveChanges(DataMessage.Update(model, newModel));
                }
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
