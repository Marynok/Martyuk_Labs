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
        private readonly ILogger _logger;
        public DatabaseController(IDataBase database, ILogger logger)
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
                _logger.Log(DataMessage.Create(model));
                _database.SaveData<TModel>();
            }
        }
        public void Delete(TModel model)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (model != null)
            {
               var deletedModel = Search(m => m.Id == model.Id);
                if (models.Remove(deletedModel)) 
                    _logger.Log(DataMessage.Delete(model));
                _database.SaveData<TModel>();
            }
        }
        public void Update(TModel newModel)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (newModel != null)
            {
                var updatedModel = Search(m => m.Id == newModel.Id);
                var index = models.IndexOf(updatedModel);
                if (index > -1)
                {
                    models.RemoveAt(index);
                    models.Insert(index, newModel);
                    _logger.Log(DataMessage.Update(updatedModel, newModel));
                    _database.SaveData<TModel>();
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
