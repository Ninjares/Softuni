using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_comparitor
{
    class Program
    {
        
        static int compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0)
            {
                if (x > y) return 1;
                else if (x < y) return -1;
                else return 0;
            }
            else if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else if (x % 2 != 0 && y % 2 != 0)
            {
                if (x > y) return 1;
                else if (x < y) return -1;
                else return 0;
            }
            else return 1;
        }
        // -1 smallet than
        // 0 equal
        // 1 larger than
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Comparison<int> even = new Comparison<int>(compare);

            Array.Sort(numbers, even);
            Console.WriteLine(string.Join(' ',numbers));


        }
    }
}
