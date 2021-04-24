using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Basket : Model
    {
        public Client Client { get; set; }
        public IList<OrderFoodData> SelectedItems { get; set; }
        public Basket(int id, Client client) : base(id)
        {
            Client = client;
            SelectedItems = new List<OrderFoodData>();
        }
        public void AddItem(OrderFoodData orderFoodData)
        {
            SelectedItems.Add(orderFoodData);
        }
        public void ClearItems()
        {
            SelectedItems.Clear();
        }
        public override string ToString()
        {
            return $"{Id} {Client} {SelectedItems}";
        }
    }
}
