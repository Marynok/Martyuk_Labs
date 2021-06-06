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
        private readonly string _folder;

        public DirectoryMaker(string folder)
        {
            _folder = folder;
        }

        public string GetPathToDirectory()
        {
            var newPath = AppDomain.CurrentDomain.BaseDirectory + _folder;
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);
            return newPath;
        }

        public abstract string GetFullPath(string fileName);
    }
}
