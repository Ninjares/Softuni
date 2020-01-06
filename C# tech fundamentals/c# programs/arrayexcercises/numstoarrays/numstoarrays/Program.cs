using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numstoarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] first = new int[n];
            int[] second = new int[n];
            for (int i=0; i<n; i++)
            {
                string input = Console.ReadLine();
                string[] cells = input.Split();

                if (i % 2 == 0)
                {
                    first[i] = int.Parse(cells[0]);
                    second[i] = int.Parse(cells[1]);
                }
                else
                {
                    second[i] = int.Parse(cells[0]);
                    first[i] = int.Parse(cells[1]);
                }
            }
            foreach (int numba in first) Console.Write(numba + " ");
            Console.WriteLine();
            foreach (int numba in second) Console.Write(numba + " ");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
