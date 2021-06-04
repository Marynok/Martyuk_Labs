﻿using DeliveryService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.DataController.Logger
{
    public class DeliveryLogger: ILogger
    {
        private readonly string _folder;
        private readonly string _fileType ;
        public DeliveryLogger(string folder, string fileType)
        {
            _folder = $"{folder}";
            _fileType = $".{fileType}";
        }
        private string GetPath()
        {
            var newPath = AppDomain.CurrentDomain.BaseDirectory + _folder;
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);
            
            return newPath;
        }

        private string GetFileName()
        {
            var todayFile = DateTime.Now.ToShortDateString();
            return "ChangesOn" + todayFile;
        }

        public void Log(string message)
        {
            var pathParts = new[]
            {
               GetPath(),
               GetFileName()+
                _fileType
            };

            using var stream = new StreamWriter(Path.Combine(pathParts),true, Encoding.UTF8);
            stream.AutoFlush = true;
            stream.WriteLine(message);
        }

    }
}
