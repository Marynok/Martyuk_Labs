using DeliveryService.Abstracts;
using DeliveryService.Interfaces;
using DeliveryService.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryService.DataSaver
{
    public class DeliveryDataSaver: DirectoryMaker, IDataSaver
    {
        private const string _type = ".json";
        public DeliveryDataSaver(string folder):base(folder)
        {}

        public override string GetFullPath(string fileName)
        {
            return Path.Combine(new[]
            {
                GetPathToDirectory(),
                fileName + _type
            });
        }

        public void SaveToFile<TModel>(IList<TModel> modelsList, string fileName) where TModel : Model
        {
            var serialized = JsonSerializer.Serialize(modelsList);

            using var file = new FileStream(GetFullPath(fileName), FileMode.Create);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.Write(serialized);
        }

        public IList<TModel> ReadFromFile<TModel>(string fileName) where TModel : Model
        {
            if (File.Exists(GetFullPath(fileName)))
            {
                using var file = new FileStream(GetFullPath(fileName), FileMode.Open);
                using var stream = new StreamReader(file, Encoding.UTF8);
                var models = stream.ReadToEnd();
               return JsonSerializer.Deserialize<IList<TModel>>(models);
            }
            return new List<TModel>();
        }
    }
}
