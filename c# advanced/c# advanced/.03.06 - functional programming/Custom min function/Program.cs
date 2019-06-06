using System;
using System.Linq;

namespace Custom_min_function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> min = numbas =>
            {
                int minV = int.MaxValue;
                foreach (int num in numbas) if (minV > num) minV = num;
                return minV;
            };
            Console.WriteLine(min(numbers));
        }
    }
}
