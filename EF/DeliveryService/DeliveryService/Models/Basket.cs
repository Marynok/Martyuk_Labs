using DeliveryService.Models.Base;
using System.Collections.Generic;

namespace DeliveryService.Models
{
    public class Basket : BaseModel
    {
        public Client Client { get; set; }
        public IList<OrderFoodData> SelectedItems { get; set; }
 
        public override string ToString()
        {
            return $"{Id} {Client} {SelectedItems}";
        }
    }
}
