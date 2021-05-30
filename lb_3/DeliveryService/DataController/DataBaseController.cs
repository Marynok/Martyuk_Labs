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
        private readonly ICasheController _cashe;
        public DatabaseController(IDataBase database, IDataLogger logger, ICasheController cashe)
        {
            _database = database;
            _logger = logger;
            _cashe = cashe;
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
                    _cashe.SetToCasheInThread(_cashe.RemoveFromCashe, null, model);
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
                    _cashe.SetToCasheInThread(_cashe.RemoveFromCashe, _cashe.SetToCashe, newModel);
                }
            }
        }

        public TModel Search(Func<TModel, bool> func)
        {
            var model = _cashe.Search(func);
            if(model is null) 
            {
                var models = (IList<TModel>)_database.Database[typeof(TModel)];
                model = models.SingleOrDefault(func);
                if (!(model is null))
                    _cashe.SetToCasheInThread(_cashe.RemoveFromCashe, _cashe.SetToCashe, model);
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
