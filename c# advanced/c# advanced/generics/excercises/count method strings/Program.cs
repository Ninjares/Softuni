using System;
using System.Collections.Generic;

namespace count_method_strings
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
        class comparer<T> where T: IComparable
        {
            public static int compare(List<T> list, T compareto)
            {
                int count = 0;
                foreach(T cmp in list)
                {
                    if (cmp.CompareTo(compareto) == 1) count++;
                }
                return count;

            }
        }
        static void Main(string[] args)
        {
            List<string> collection = new List<string>();
            int n = int.Parse(Console.ReadLine());
            while (n != 0)
            {
                collection.Add(Console.ReadLine());
                n--;
            }

            Console.WriteLine(comparer<string>.compare(collection, Console.ReadLine()));
        }
    }
}
