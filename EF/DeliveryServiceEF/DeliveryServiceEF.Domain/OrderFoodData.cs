using DeliveryServiceEF.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace DeliveryServiceEF.Domain
{
    public class OrderFoodData: BaseModel
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Count { get; set; }
        [NotMapped]
        public decimal TotalPrice { get { return Count * Food.Price; } }
  
        public override string ToString()
        {
            return $" {Food.Name} {TotalPrice}$ {Count}pc.";
        }
    }
}
