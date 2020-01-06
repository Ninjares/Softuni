using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0x;
            Console.WriteLine(a);
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            for (a = 0; a < uint.MaxValue; a++) ;
            Console.WriteLine(sw.Elapsed); 
            Console.ReadKey();

           
        }
    }
}
