using DeliveryService.Abstracts;
using DeliveryService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DataController.Logger
{
    public class DataLogger: DirectoryMaker, IDataLogger
    {
        private string _fileType ;
        public DataLogger(string folder, string fileType)
        {
            Folder = $"/{folder}";
            _fileType = $".{fileType}";
        }
        private string GetFileName(String fileName)
        {
            var todayFile = DateTime.Now.ToShortDateString();
            return fileName + todayFile;
        }
        public override string GetFullPath(String fileName)
        {
            var pathParts = new[]
            {
               GetPathToDirectory(),
               GetFileName(fileName)+_fileType
            };

            return Path.Combine(pathParts);
        }
        public void SaveChanges(string content)
        {
            using var stream = new StreamWriter(GetFullPath("ChangesOn"), true, Encoding.UTF8);
            stream.AutoFlush = true;
            stream.Write(content + '\n');
        }

    }
}
