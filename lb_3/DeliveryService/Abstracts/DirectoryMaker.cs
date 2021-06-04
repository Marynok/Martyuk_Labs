using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Abstracts
{
    public abstract class DirectoryMaker
    {
        public string Folder { get; set; }
        public DirectoryMaker(string folder)
        {
            Folder = folder;
        }
        public string GetPathToDirectory()
        {
            var newPath = AppDomain.CurrentDomain.BaseDirectory + Folder;
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);
            return newPath;
        }
        public abstract string GetFullPath(string fileName);
    }
}
