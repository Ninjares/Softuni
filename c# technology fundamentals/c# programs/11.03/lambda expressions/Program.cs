using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda_expressions
{
    class Program
    {
        static bool largerthanfive(int a)
        {
            return a > 5;
        }

        static string getkey(int a)
        {
            return "_"+(a + 1).ToString() + "_";
        }
        static void Main(string[] args)
        { 
            int[] numbers = { 1, 2, 5, 6, 10, 7 };
            var newnumbers = numbers.Where(largerthanfive).ToDictionary(getkey);         //to dictionary requires a key creation function
            var lambdanumber = numbers.Where(a => a > 5).ToDictionary(x => "_" + x + "_");
            foreach(var num in newnumbers)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
            int[] parsednumbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Console.WriteLine();
            Console.WriteLine(string.Join("\n", newnumbers)+"\n");
            Console.WriteLine(string.Join("\n", lambdanumber)+"\n");
            Console.WriteLine(string.Join("\n", parsednumbers) + "\n");
            Console.ReadKey();
          
        }
    }
}
