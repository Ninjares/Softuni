using System;
using System.Collections.Generic;
using System.Linq;

namespace boxofstring
{
    class Program
    {
        public class Box<T>
        {
            public T item;

            public Box(T item)
            {
                this.item = item;
            }

            public override string ToString()
            {
                return $"{typeof(T)}: {item}";
            }
        }

        
        
            public static void Swap<T>(List<T> list, int pos1, int pos2)
            {
                T help = list[pos1];
                list[pos1] = list[pos2];
                list[pos2] = help;
            }
        

        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();
            for(int i=0; i<n; i++)
            {
                boxes.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }
            int[] pos = Console.ReadLine().Split().Select(int.Parse).ToArray();
            boxes = Swapper<Box<int>>.Swap(boxes, pos[0], pos[1]);
            foreach(Box<int> bocs in boxes)
            {
                Console.WriteLine(bocs.ToString());
            }
        }
    }
}
