using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_text_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            int ops = int.Parse(Console.ReadLine());
            Stack<string> stackoftext = new Stack<string>();
            for (int i = 0; i < ops; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (int.Parse(command[0]))
                {
                    case 1:
                        {
                            text.Append(command[1]);
                            stackoftext.Push(command[1]);
                            break;
                        }
                    case 2:
                        {
                            int count = int.Parse(command[1]);
                            while (count != 0&&stackoftext.Count!=0)
                            {
                                stackoftext.Pop();
                            }
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                }
            }
            Console.ReadKey();
        }
    }
}
