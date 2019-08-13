using System;
using System.Collections.Generic;

namespace TowerOfHanoi
{
    class Program
    {
        static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
                destination.Push(source.Pop());
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                destination.Push(source.Pop());
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }
        static void Main(string[] args)
        {
            Stack<int> source = new Stack<int>();
            Stack<int> destination = new Stack<int>();
            Stack<int> spare = new Stack<int>();



            int disks = int.Parse(Console.ReadLine());
            for (int i = disks; i >= 1; i--) source.Push(i);
            MoveDisks(disks, source, destination, spare);


            Console.WriteLine();
        }
    }
}
