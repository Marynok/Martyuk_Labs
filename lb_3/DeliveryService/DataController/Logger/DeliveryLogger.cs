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
    public class DeliveryLogger: DirectoryMaker, ILogger
    {
        private readonly string _fileType ;
        public DeliveryLogger(string folder, string fileType):base(folder)
        {
            _fileType = $".{fileType}";
        }

        private string GetFileName(string fileName)
        {
            var todayFile = DateTime.Now.ToShortDateString();
            return fileName + todayFile;
        }

        public override string GetFullPath(string fileName)
        {
            return Path.Combine(new[]
            {
               GetPathToDirectory(),
               GetFileName(fileName)+_fileType
            });
        }

        public void Log(string message)
        {
            using var stream = new StreamWriter(GetFullPath("ChangesOn"), true, Encoding.UTF8);
            stream.AutoFlush = true;
            stream.WriteLine(message);
        }

    }
}
