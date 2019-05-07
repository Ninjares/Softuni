using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambdaexcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var b0is = Console.ReadLine().Split(' ').OrderBy(x => x[0]).ThenBy(x => x.Length);
            Console.WriteLine(string.Join("\n", b0is));
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(string.Join("\n", nums));
            Console.ReadKey();
        }
    }
}
