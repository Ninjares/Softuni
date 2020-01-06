using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    class swap
    {
        public static unsafe void swp(string* a, int* b)
        {
           int help = *b;
            *b = *a;
            *a = help;
        }
    }
    class Program
    {
    
        static void Main(string[] args)
        {
            string[] cards = { "AS", "10H", "2C", "KD" };
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}