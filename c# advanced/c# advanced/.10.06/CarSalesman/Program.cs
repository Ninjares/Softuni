using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int nengines = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            while (nengines != 0)
            {
                string[] info = Console.ReadLine().Split();
                engines.Add(info[0], new Engine(info[0], int.Parse(info[1])));
            }

        }
    }
}
