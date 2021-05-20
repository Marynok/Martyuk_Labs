using DeliveryService.Models.BaseModel;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DeliveryService.Interfaces
{
    public interface  IDataBase
    {
        Dictionary<Type, IList> Database { get; set; }
        void InitializeData();
        void ReadData();
        void SaveData<TModel>() where TModel : Model;
    }
}
