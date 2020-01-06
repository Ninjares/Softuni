using System;
using System.Linq;
using System.Numerics;

namespace Recursion
{
    class Program
    {
        static int recursiveSummer(int[] array, int pos = 0)
        {
            if (pos == array.Length) return 0;
            else return array[pos] + recursiveSummer(array, pos + 1);
        }
        static long Factorial(int n)
        {
            if (n == 1) return n;
            else return n * Factorial(n - 1);
        }
        static void Main(string[] args)
        {
            int[] sum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(recursiveSummer(sum));
            Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));
            
        }
        
    }
}
