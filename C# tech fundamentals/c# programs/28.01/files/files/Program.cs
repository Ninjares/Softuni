using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace files
{
    class Program
    {
        static void Main(string[] args)
        {
            string os = "Windows";
            string file = "b0ss.txt";
            string path = $"C:\\{os}\\{file}";
            Console.WriteLine(path);
            Console.ReadKey();
        }
    }
}
