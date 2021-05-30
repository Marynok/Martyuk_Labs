using DeliveryService.DataController.Cashe;
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
        private readonly ICacheController _cache;
        public DatabaseController(IDataBase database, IDataLogger logger, ICacheController cache)
        {
            _database = database;
            _logger = logger;
            _cache = cache;
        }

        public void AddModel(TModel model)
        {
            var models = (IList<TModel>)_database.Database[typeof(TModel)];
            if (model != null)
            {
                model.Id = GetId();
                models.Add(model);
                _logger.SaveChanges(DataMessage.Create(model));
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
                {
                    _logger.SaveChanges(DataMessage.Delete(model));
                    _cache.SetToCasheInThread(_cache.RemoveFromCashe, null, model);
                }
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
                    _logger.SaveChanges(DataMessage.Update(updatedModel, newModel));
                    _database.SaveData<TModel>();
                    _cache.SetToCasheInThread(_cache.RemoveFromCashe, _cache.SetToCashe, newModel);
                }
            }
        }

        public TModel Search(Func<TModel, bool> func)
        {
            var model = _cache.Search(func);
            if(model is null) 
            {
                var models = (IList<TModel>)_database.Database[typeof(TModel)];
                model = models.SingleOrDefault(func);
                if (!(model is null))
                    _cache.SetToCasheInThread(_cache.RemoveFromCashe, _cache.SetToCashe, model);
            }
           
            return model;
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
