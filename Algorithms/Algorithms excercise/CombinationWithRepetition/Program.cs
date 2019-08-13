using System;
using System.Collections.Generic;

namespace NestedLoops
{
    class Program
    {
        static void NestedLoop(int n, int m, List<int> digits)
        {
            if (m == 0)
            {
                Console.WriteLine(string.Join(" ", digits));
            }
            else
            {
                int start = 1;
                if (digits.Count != 0) start = digits[digits.Count - 1];
                for (int i = start; i <= n; i++)
                {
                    digits.Add(i);
                    NestedLoop(n, m - 1, digits);
                    digits.RemoveAt(digits.Count - 1);
                }
            }

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            NestedLoop(n, m, new List<int>());
        }
    }
}
