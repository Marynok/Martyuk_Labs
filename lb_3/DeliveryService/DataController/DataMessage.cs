using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DataController
{
    public static class DataMessage
    {
        private static string Message(Model model) => $"In table { model.GetType().Name}";
        public static string Create(Model model)=> Message(model) + $" was created {model}";
        public static string Update(Model oldModel, Model model) => Message(model) + $" was updated {oldModel} to {model}";
        public static string Delete(Model model) => Message(model)+ $" was deleted {model}";

    }
}
