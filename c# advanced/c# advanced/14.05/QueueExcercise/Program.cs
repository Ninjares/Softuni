using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> qu = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());
            string loser = "";
            while (qu.Count != 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    string player = qu.Dequeue();
                    qu.Enqueue(player);
                }
                Console.WriteLine($"Removed {qu.Dequeue()}");

            }
            Console.WriteLine($"Last is "+loser);
            Console.ReadKey();
        }
    }
}
