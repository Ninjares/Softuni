using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = Console.ReadLine();
            int index = filepath.LastIndexOf('\\');
            filepath = filepath.Remove(0, index+1);
            string[] file = filepath.Split('.');
            Console.WriteLine("File name: "+file[0]);
            Console.WriteLine("File extension: " + file[1]);
            Console.ReadKey();
        }
    }
}
