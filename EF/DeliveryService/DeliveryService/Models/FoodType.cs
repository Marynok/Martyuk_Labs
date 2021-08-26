using Dapper.Contrib.Extensions;


namespace DeliveryService.Models
{
    public class FoodType 
    {
        [Key]
        public int FoodTypeId { get;set;}
        public string Name { get; set; }

        public override string ToString()
        {
            return $" { FoodTypeId} Name: {Name}";
        }
    }
}
