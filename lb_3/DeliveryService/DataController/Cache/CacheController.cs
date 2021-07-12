using DeliveryService.Interfaces;
using DeliveryService.Models;
using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeliveryService.DataController.Cache
{
    public class CacheController: ICacheController
    {
        private const int MaxSize = 5;
        public Dictionary<Type, Object> Locks { get; }
        private readonly ICache _cache;
       
        public CacheController(ICache cache)
        {
            _cache = cache;
            Locks = new Dictionary<Type, Object>();
        }

        public object GetLock<TModel>() where TModel : Model
        {
            if (!Locks.TryGetValue(typeof(TModel), out object locker))
            {
                locker = new object();
                Locks.Add(typeof(TModel), locker);
            }
            return locker;
        }

        public TModel GetFromCache<TModel>(Func<TModel, bool> filter) where TModel : Model
        {
            var locker = GetLock<TModel>();
            lock (locker)
            {
                var models = (IList<TModel>)_cache.Cache[typeof(TModel)];
                return models.SingleOrDefault(filter);
            }
        }

        public void TredSafeWorkWithCache<TModel>(Action<TModel, IList<TModel>> action, TModel model) where TModel : Model
        {
            var locker = GetLock<TModel>();
            lock (locker)
            {
                var models = (IList<TModel>)_cache.Cache[typeof(TModel)];
                action?.Invoke(model, models);
            }
        }

        public void SetToCache<TModel>(TModel model, IList<TModel> models) where TModel : Model
        {
            RemoveFromCache(model, models);

            if (models.Count > MaxSize)
                models.RemoveAt(MaxSize - 1);

            models.Insert(0, model);
        }

        public void RemoveFromCache<TModel>(TModel model, IList<TModel> models) where TModel : Model
        {
            var sameModel = models.SingleOrDefault(m => m.Id == model.Id);

            if (!(sameModel is null))
                models.Remove(sameModel);
        }
    }
}
