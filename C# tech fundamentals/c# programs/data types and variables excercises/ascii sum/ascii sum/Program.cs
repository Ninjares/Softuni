using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ascii_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int x = 0; x < n; x++)
                        Console.WriteLine("{0}{1}{2}", (char)(97+i) , (char)(97 + j), (char)(97 + x));
            Console.ReadKey();
        }
    }
}
