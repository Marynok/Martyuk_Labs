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
        private const int MaxSize = 5;
        private ICache _cache;
        public CacheController(ICache cache)
        {
            _cache = cache;
        }

        public TModel GetFromCache<TModel>(Func<TModel, bool> filter) where TModel : Model
        {
            var models = _cache.GetList<TModel>();
            return models.SingleOrDefault(filter);
        }

        public void SetToCache<TModel>(TModel model,IList<TModel> models) where TModel : Model
        {
            if (models.Count > MaxSize)
                models.RemoveAt(MaxSize - 1);

            models.Insert(0,model);
        }

        public void RemoveFromCache<TModel>(Action<TModel, IList<TModel>> action,TModel model) where TModel : Model
        {
            var models = _cache.GetList<TModel>();
            var locker = _cache.Locks[typeof(TModel)];
            lock (locker)
            {
                var sameModel = GetFromCache<TModel>(m => m.Id == model.Id);
                if (!(sameModel is null))
                    models.Remove(sameModel);
                action?.Invoke(model, models);
            }
        }

    }
}
