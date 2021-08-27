using DeliveryServiceEF.Domain.Base;
using System.Collections.Generic;

namespace DeliveryServiceEF.Domain
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
