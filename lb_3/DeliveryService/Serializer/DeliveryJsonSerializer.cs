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

namespace DeliveryService.Serializer
{
    public class DeliveryJsonSerializer: DirectoryMaker, ISerializer
    {
        private const string type = ".json";
        public DeliveryJsonSerializer(string folder):base(folder)
        {}

        public override string GetFullPath(string fileName)
        {
            return Path.Combine(new[]
            {
                GetPathToDirectory(),
                fileName + type
            });
        }

        public void SerializeToFile<TModel>(IList<TModel> modelsList, string fileName) where TModel : Model
        {
            var serialized = JsonSerializer.Serialize(modelsList);

            using var file = new FileStream(GetFullPath(fileName), FileMode.Create);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.Write(serialized);
        }

        public IList<TModel> DeserializeFromFile<TModel>(string fileName) where TModel : Model
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
