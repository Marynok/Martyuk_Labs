using DeliveryService.Models.BaseModel;
using System.Collections.Generic;

namespace DeliveryService.Models
{
    public class Basket : Model
    {
        public Client Client { get; set; }
        public IList<OrderFoodData> SelectedItems { get; set; }
        public Basket(Client client) 
        {
            Client = client;
            SelectedItems = new List<OrderFoodData>();
        }
        public Basket(int id, Client client) : base(id)
        {
            Client = client;
            SelectedItems = new List<OrderFoodData>();
        }
        public override string ToString()
        {
            return $"{Id} {Client} {SelectedItems}";
        }
    }
}
