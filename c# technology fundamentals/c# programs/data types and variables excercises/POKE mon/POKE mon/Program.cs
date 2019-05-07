using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POKE_mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int initialn = n;
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int targets = 0;
            while (n >= m)
            {
                n -= m;
                targets++;
                if (n * 2 == initialn&&y!=0)
                {
                    //if (n % y == 0)
                    //n = initialn;
                    n /= y;

                }
            }
            Console.WriteLine(n +"\n"+ targets);
            Console.ReadKey();
        }
    }
}
