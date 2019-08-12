using System;
using System.Linq;

namespace Reverse_array
{
    class Program
    {
        static void PrintReverse(int[] array, int pos = 0)
        {
            if (pos < array.Length-1) PrintReverse(array, pos + 1);
            Console.Write(array[pos]+" ");
        }
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            PrintReverse(array);
        }
    }
}
