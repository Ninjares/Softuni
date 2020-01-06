using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gauss__trick
{
    class Program
    {
        static void printlist(List<int> a)
        {
            foreach (int num in a) Console.Write(num + " ");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //merge lists
            var firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var result = new List<int>();
            for(int i =0; i<Math.Max(firstList.Count, secondList.Count); i++)
            {
                if (i < firstList.Count) result.Add(firstList[i]);
                if (i < secondList.Count) result.Add(secondList[i]);
            }
            printlist(result);
            Console.ReadKey();
            
        }
    }
}
