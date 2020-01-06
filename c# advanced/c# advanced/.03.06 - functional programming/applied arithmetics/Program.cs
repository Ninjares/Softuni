using System;
using System.Linq;

namespace applied_arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int> add = x => x += 1;
            Func<int, int> sub = x => x -= 1;
            Func<int, int> mul = x => x *= 2;

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        {
                            numbers = numbers.Select(x => add(x)).ToArray();
                            break;
                        }
                    case "subtract":
                        {
                            numbers = numbers.Select(x => sub(x)).ToArray();
                            break;
                        }
                    case "multiply":
                        {
                            numbers = numbers.Select(x => mul(x)).ToArray();
                            break;
                        }
                    case "print":
                        {
                            Console.WriteLine(string.Join(' ', numbers));
                            break;
                        }
                }
                command = Console.ReadLine();
            }
        }
    }
}
