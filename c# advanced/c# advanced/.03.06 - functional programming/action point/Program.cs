using System;

namespace action_point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> print = array => Console.WriteLine(string.Join('\n', array));

            print(names);
        }
    }
}
