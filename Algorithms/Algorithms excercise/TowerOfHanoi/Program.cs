using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    class Program
    {
        static Stack<int> source = new Stack<int>();
        static Stack<int> destination = new Stack<int>();
        static Stack<int> spare = new Stack<int>();
        static int step = 1;
        static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
        static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{step}: Moved disk {destination.Peek()}");
                PrintRods();
                step++;
            }

            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{step}: Moved disk {destination.Peek()}");
                PrintRods();
                step++;
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }
        static void Main(string[] args)
        {
            source = new Stack<int>();
            destination = new Stack<int>();
            spare = new Stack<int>();



            int disks = int.Parse(Console.ReadLine());
            for (int i = disks; i >= 1; i--) source.Push(i);
            PrintRods();
            MoveDisks(disks, source, destination, spare);
        }
    }
}
