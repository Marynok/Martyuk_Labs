using DeliveryService.Interfaces;
using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeliveryService.DataController.Cashe
{
    public class CacheController: ICacheController
    {
        private const int MAX_SIZE = 5;
        private ICache _cache;
        public CacheController(ICache cache)
        {
            _cache = cache;
        }

        public TModel Search<TModel>(Func<TModel, bool> func)
        {
            var models = _cache.GetList<TModel>();
            return models.SingleOrDefault(func);
        }

        public void SetToCashe<TModel>(TModel model,IList<TModel> models) where TModel : Model
        {
            if (models.Count > MAX_SIZE)
                models.RemoveAt(MAX_SIZE - 1);

            models.Insert(0,model);
        }
        public void RemoveFromCashe<TModel>(Action<TModel, IList<TModel>> action,TModel model) where TModel : Model
        {
            var models = _cache.GetList<TModel>();
            var locker = _cache.Locks[typeof(TModel)];
            lock (locker)
            {
                var sameModel = Search<TModel>(m => m.Id == model.Id);
                if (!(sameModel is null))
                    models.Remove(sameModel);
                action?.Invoke(model, models);
            }
        }
        public void SetToCasheInThread<TModel>(Action<Action<TModel, IList<TModel>>, TModel> action,
                                                            Action<TModel, IList<TModel>> secAction, 
                                                            TModel model) where TModel : Model
        {
            var thread = new Thread(() => action(secAction, model));
            thread.Start();
        }

    }
}
