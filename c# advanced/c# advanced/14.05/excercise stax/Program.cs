using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excercise_stax
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stacc = new Stack<int>();
            string[] command = Console.ReadLine().Split();
            foreach (string num in command) stacc.Push(int.Parse(num));
            command = Console.ReadLine().ToLower().Split();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        {
                            int a = int.Parse(command[1]);
                            int b;
                            int.TryParse(command[2], out b);
                            stacc.Push(a);
                            stacc.Push(b);
                            break;
                        }
                    case "remove":
                        {
                            
                            int n;
                            int.TryParse(command[1], out n);
                            if (stacc.Count >= n)
                            {
                                while (n != 0)
                                {
                                    stacc.Pop();
                                    n--;
                                }
                            }
                            break;
                        }
                }
                command = Console.ReadLine().ToLower().Split();
            }
              //int sum = 0;
              //while (stacc.Count != 0) sum += stacc.Pop();
                Console.WriteLine($"Sum: {stacc.Sum()}");

            Console.ReadKey();
        }
    }
}
