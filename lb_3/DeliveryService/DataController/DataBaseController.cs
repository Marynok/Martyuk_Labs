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
        private readonly ILogger _logger;
        private readonly ICacheController _cache;
        public DatabaseController(IDataBase database, ILogger logger, ICacheController cache)
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
                _cache.RemoveFromCache(null, model);
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
                    _cache.RemoveFromCache(_cache.SetToCache, newModel);
                }
            }
        }

        public TModel Search(Func<TModel, bool> func)
        {
            var model = _cache.GetFromCache(func);
            if(model is null) 
            {
                var models = (IList<TModel>)_database.Database[typeof(TModel)];
                model = models.SingleOrDefault(func);
                if (!(model is null))
                    _cache.RemoveFromCache( _cache.SetToCache, model);
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
