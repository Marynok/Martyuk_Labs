using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Settings
{
    public class SettingDb
    {
        private string _settingsFile;
        public string ConnectionString { get => Initialize(). GetConnectionString("DefaultConnection");  }

        public SettingDb(string settingsFile) => _settingsFile = settingsFile;

        private IConfiguration Initialize()
        {
            Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_settingsFile, optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
