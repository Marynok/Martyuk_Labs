using System;
using System.Collections.Generic;
using DeliveryService.models.baseModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.models
{
    public class Company: Model
    {
        public string Name { get; set; }
        public Address CompanyAddress { get; set; }
        public string Description { get; set; }
        public List<Food> Foods { get; set; }

    }
}
