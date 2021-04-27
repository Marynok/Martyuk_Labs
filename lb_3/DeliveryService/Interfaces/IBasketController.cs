using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface IBasketController
    {
        Basket Basket { get; }
        void SetBasket(Client client);
        IEnumerable<OrderFoodData> GetBasketItems();
        void CreateBasket(Client client);
        void ClearBasket();
        OrderFoodData AddToBasket(int id, int count);
    }
}
