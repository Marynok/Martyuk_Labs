﻿using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    public interface ISerializer
    {
        void SerializeToFile<TModel>(IList<TModel> modelsList, string fileName) where TModel : Model;
        IList<TModel> DeserializeFromFile<TModel>(string fileName) where TModel : Model;
    }
}
