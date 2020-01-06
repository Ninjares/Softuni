using System;
using System.Linq;

namespace reverse_and_exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            int divisor = int.Parse(Console.ReadLine());
            Func<int, int, bool> isDiv = (n, div) =>
            {
                if (n % div == 0)
                    return true;
                else return false;
            };
            Console.WriteLine(string.Join(' ', numbers.Where(x => !isDiv(x, divisor))));

        }
    }
}
