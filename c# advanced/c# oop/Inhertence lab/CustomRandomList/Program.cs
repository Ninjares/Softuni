using System;

namespace CustomRandomList
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomList<int> list = new RandomList<int>();
            list.Add(2);
            list.Add(5);
            list.Add(8);
            list.Add(-2);
            Console.WriteLine($"Numba: {list.RandomElement()}");
        }
    }
}
