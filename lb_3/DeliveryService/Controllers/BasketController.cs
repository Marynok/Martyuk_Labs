using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Collections.Generic;

namespace DeliveryService.Controllers
{
    public class BasketController: IBasketController
    {
        private Basket _basket;
        public Basket Basket { get => _basket; }
        private readonly IDatabaseController<Basket> _baskets;
        private readonly IDatabaseController<Food> _food;
        public BasketController(IDatabaseController<Basket> baskets, IDatabaseController<Food> food)
        {
            _baskets = baskets;
            _food = food;
        }
        public void SetBasket(Client client)
        {
            _basket = _baskets.Search(b => b.Client == client);
            if (_basket is null)
                CreateBasket(client);
        }
        public IEnumerable<OrderFoodData> GetBasketItems()
        {
            for(var i =0; i<_basket.SelectedItems.Count; i++)
            {
                var item = _food.Search(f => f.Id == _basket.SelectedItems[i].Food.Id);
                if (item is null)
                {
                    _basket.SelectedItems.RemoveAt(i);
                    i--;
                }
                else
                if (item != _basket.SelectedItems[i].Food)
                    _basket.SelectedItems[i].Food = item;
            }
            return _basket.SelectedItems;
        }
        public void CreateBasket(Client client)
        {
            _basket = new Basket(client);
            _baskets.AddModel(Basket);
        }
        public void ClearBasket()
        {
            if (Basket != null)
                _basket.SelectedItems.Clear();
        }
        public OrderFoodData AddToBasket(int id, int count)
        {
            var food = _food.Search(f => f.Id == id);
            if (food is null)
                return null;
            else
            {
                var foodData = new OrderFoodData(count, food);
                _basket.SelectedItems.Add(foodData);
                return foodData;
            }
        }
    }
}
