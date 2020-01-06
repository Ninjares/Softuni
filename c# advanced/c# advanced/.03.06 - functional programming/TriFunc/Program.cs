using System;
using System.Linq;

namespace TriFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            int charsum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> EqualOrLargerThanSum = (name, sum) =>
            {
                int charSum = 0;
                foreach (char a in name) charSum += (int)a;
                if (charSum >= sum) return true;
                else return false;
            };
            Console.WriteLine(string.Join(' ', names.Where(x => EqualOrLargerThanSum(x, charsum))));
        }
    }
}
