using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryServiceEF.Domain.Base
{
     public abstract class BaseModel
     { 
        public int Id { get; set; }
        public BaseModel(){}

        public BaseModel(int id)
        {
            Id = id;
        }
    }
}

