using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directorytomesswith = ".";
            var test = Directory.GetFiles(directorytomesswith, "*.*");
            Console.WriteLine(string.Join("\n",test)+"\n");

            var dirInfo = new Dictionary<string,Dictionary<string, double>>();

            var directoryInfo = new DirectoryInfo(directorytomesswith);

            var allFiles = directoryInfo.GetFiles();

            foreach(var currentFile in allFiles)
            {
                double size = currentFile.Length / 1024d;
                string fileName = currentFile.Name;
                string extension = currentFile.Extension;
                if (!dirInfo.ContainsKey(extension)) dirInfo.Add(extension, new Dictionary<string, double>());
                if (!dirInfo[extension].ContainsKey(fileName)) dirInfo[extension].Add(fileName, size);
            }

            dirInfo = dirInfo.OrderByDescending(x => x.Value.Count).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);

                         //key     value
            foreach(var (extension,value) in dirInfo)
            {
                Console.WriteLine(extension);
                foreach(var (filename, size) in value)
                {
                    Console.WriteLine($"--{filename} - {size:F3}kb");
                }

            }
        }
    }
}
