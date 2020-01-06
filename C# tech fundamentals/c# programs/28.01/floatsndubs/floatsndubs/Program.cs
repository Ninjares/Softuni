using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace floatsndubs
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            for(int i=0; i<100000; i++)
            {
                a += 0.00001;
            }
            Console.WriteLine(a);
            decimal b = 0;
            for (int i = 0; i < 100000; i++)
            {
                b += 0.00001M;
            }
            Console.WriteLine(b);
            Console.WriteLine(decimal.MaxValue);
            Console.WriteLine(decimal.MinValue);
            //BOOL true = 00000001 = 1; false = 00000000 = 0
            bool y = true;
            bool x = false;
            //chars - '\0' acts as a end to a char array - win-1251 ascii table extension; unicode; '\\' is unique
            char z = '♕';
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(z);
            string xx = "A   \u265B";
            Console.Write(xx);
            Console.ReadKey();
        }
    }
}
