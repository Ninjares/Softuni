using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyonesprojectground
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stacc = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            Stack<int> max = new Stack<int>();
            Stack<int> min = new Stack<int>();
            while (n != 0)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
                switch (command[0])
                {
                    case 1:
                        {
                            stacc.Push(command[1]);

                            if (min.Count == 0) min.Push(command[1]);
                            else if (command[1] < min.Peek()) min.Push(command[1]);

                            if (max.Count == 0) max.Push(command[1]);
                            if (command[1] > max.Peek()) max.Push(command[1]);
                            break;
                        }
                    case 2:
                        {
                            if (stacc.Count != 0)
                            {
                                int el = stacc.Pop();
                                if (min.Count != 0)
                                    if (el == min.Peek()) min.Pop();
                                if (max.Count != 0)
                                    if (el == max.Peek()) max.Pop();
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(max.Peek());
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(min.Peek());
                            break;
                        }
                }
                n--;
            }
            Console.WriteLine(string.Join(", ", stacc));
            Console.ReadKey();
        }
    }
}
