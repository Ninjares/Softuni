using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fasttfood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodcount = int.Parse(Console.ReadLine());
            int[] ordarr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(ordarr);
            int biggestorder = orders.Max();
            while (orders.Count != 0 && foodcount>0)
            {

                if (foodcount >= orders.Peek())
                {
                    //if (orders.Peek() > biggestorder) biggestorder = orders.Peek();
                    foodcount -= orders.Dequeue();
                }
                else break;
            }
            Console.WriteLine(biggestorder);
            if (orders.Count == 0) Console.WriteLine("Orders complete");
            else Console.WriteLine("Orders left: " + string.Join(" ", orders));
            Console.ReadKey();
        }
    }
}
