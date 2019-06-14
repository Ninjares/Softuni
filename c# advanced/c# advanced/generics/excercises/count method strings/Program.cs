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
        
            public static int compare<T>(List<T> list, T compareto) where T: IComparable
            {
                int count = 0;
                foreach(T cmp in list)
                {
                    if (cmp.CompareTo(compareto) == 1) count++;
                }
                return count;

            }
        static void Main(string[] args)
        {
            List<double> collection = new List<double>();
            int n = int.Parse(Console.ReadLine());
            while (n != 0)
            {
                collection.Add(double.Parse(Console.ReadLine()));
                n--;
            }

            Console.WriteLine(compare<double>(collection, double.Parse(Console.ReadLine())));
        }
    }
}
