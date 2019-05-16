using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_tour
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var petrolpumps = new Queue<int[]>();
            for(int i=0; i<n; i++)
            {
                int[] petrolpump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                petrolpumps.Enqueue(petrolpump);
            }

            int index = 0;
            int tank = 0;
            while (true)
            {
                foreach(var petrolPump in petrolpumps)
                {
                    int[] currentpump = petrolpumps.Peek();

                    int petroamnt = currentpump[0];
                    int disttonext = currentpump[1];

                    tank += petroamnt - disttonext;
                    if (tank < 0)
                    {
                        petrolpumps.Enqueue(petrolpumps.Dequeue());
                        index++;
                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
