using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicc_som
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitter = input.Split();
            int[] numbers = new int[splitter.Length];
            for (int i = 0; i <numbers.Length; i++)
                            numbers[i] = int.Parse(splitter[i]);
            int sumpair = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Length; i++)
                for (int j = i + 1; j < numbers.Length; j++)
                    if (numbers[i] + numbers[j] == sumpair) Console.WriteLine("{0} {1}", numbers[i], numbers[j]);
            Console.ReadKey();
        }
    }
}
