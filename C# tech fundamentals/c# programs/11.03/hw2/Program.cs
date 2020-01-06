using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> metals = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "stop")
            {
                int value = int.Parse(Console.ReadLine());
                if (!metals.ContainsKey(input))
                    metals.Add(input, value);
                else metals[input] += value;
                input = Console.ReadLine();
            }
            foreach (var kvp in metals) Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            Console.ReadKey();
        }
    }
}
