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

            int GCN = 0; //nay-malko obshto delimo
            bool found = false;
            for (int i = 1; i <= n && !found; i++)
            {
                bool divisable = true;
                foreach (int divisor in divisors)
                    if (i % divisor != 0) { divisable = false; }
                if (divisable) { GCN = i; found = true; }
            }
           // Console.WriteLine(string.Join(", ", divisors));
            for (int i = GCN; i <= n; i += GCN) Console.Write($"{i} ");
        }
    }
}
