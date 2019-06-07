using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> divisors = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToHashSet();

            Func<int, HashSet<int>, bool> div = (number, divisor) =>
            {
                bool a = true;
                foreach (int divider in divisor)
                {
                    if (number % divider != 0) { a = false; break; }

                }
                return a;
            };


            for (int i = 1; i <= n; i++)
            {
                if (div(i, divisors)) Console.Write($"{i} ");
            }
        }
    }
}
