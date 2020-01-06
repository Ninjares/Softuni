using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace someother_demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("temp");
            File.WriteAllText(@"temp\\output.txt", "Tova e testov text");
            var files = Directory.GetFiles("temp");
            FileInfo fileinfo = new FileInfo(files[0]);
            Console.WriteLine(fileinfo.FullName);
            Console.WriteLine(fileinfo.Name);
            Console.WriteLine(fileinfo.Length);
            Console.WriteLine(File.ReadAllText(fileinfo.FullName)+"\n\n");

            using(MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes())



            Console.ReadKey();
                
        }
    }
}
