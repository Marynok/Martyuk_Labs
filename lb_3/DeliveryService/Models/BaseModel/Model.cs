using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models.BaseModel
{
     public abstract class Model
     { 
        public int Id { get; set; }
        public Model(){}
        public Model(int id)
        {
            Id = id;
        }
    }
}

