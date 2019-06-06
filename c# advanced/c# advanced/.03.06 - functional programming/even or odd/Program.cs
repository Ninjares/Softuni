using System;
using System.Linq;

namespace even_or_odd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startend = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string evenorodd = Console.ReadLine();
            int[] numbers = new int[startend[1] - startend[0] + 1];
            for (int i = startend[0]; i <= startend[1]; i++) numbers[i - startend[0]] = i;

            Predicate<int> even = numba =>
            {
                if (numba % 2 == 0) return true;
                else return false;
            };

            Predicate<int> odd = numba =>
            {
                if (numba % 2 == 1||numba%2==-1) return true;
                else return false;
            };

            //Console.WriteLine(string.Join(' ', numbers));
            if (evenorodd == "even")
            {
                Console.WriteLine(string.Join(' ', numbers.Where(x => even(x))));
            }
            else
                Console.WriteLine(string.Join(' ', numbers.Where(x => odd(x))));
        }
    }
}
