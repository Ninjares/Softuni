using System;

namespace Knigts_of_honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printsirs = sirs =>
            {
                foreach (string sir in sirs) Console.WriteLine($"Sir {sir}");
            };

            printsirs(names);
        }
    }
}
