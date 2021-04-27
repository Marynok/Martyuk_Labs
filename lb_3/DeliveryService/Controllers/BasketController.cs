using DeliveryService.Interfaces;
using DeliveryService.Models;
using System.Collections.Generic;

namespace DeliveryService.Controllers
{
    public class BasketController
    {
        public Basket Basket;
        public readonly IDatabaseController<Basket> Baskets;
        public readonly IDatabaseController<Food> Food;
        public BasketController(IDatabaseController<Basket> baskets, IDatabaseController<Food> food)
        {
            Baskets = baskets;
            Food = food;
        }
        public void SetBasket(Client client)
        {
            Basket = Baskets.Search(b => b.Client == client);
            if (Basket is null)
                CreateBasket(client);
        }
        public IEnumerable<OrderFoodData> GetBasketItems()
        {
            return Basket.SelectedItems;
        }
        private void CreateBasket(Client client)
        {
            Basket = new Basket(client);
            Baskets.AddModel(Basket);
        }
        public void ClearBasket()
        {
            if (Basket != null)
                Basket.SelectedItems.Clear();
        }
        public OrderFoodData AddToBasket(int id, int count)
        {
            var food = Food.Search(f => f.Id == id);
            if (food is null)
                return null;
            else
            {
                var foodData = new OrderFoodData(count, food);
                Basket.SelectedItems.Add(foodData);
                return foodData;
            }
        }
    }
}
