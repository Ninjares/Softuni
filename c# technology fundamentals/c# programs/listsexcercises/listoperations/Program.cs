using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listoperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "Add":
                        {
                            numbers.Add(int.Parse(commands[1]));
                            break;
                        }
                    case "Remove":
                        {
                            if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) >= numbers.Count) Console.WriteLine("Invalid index");
                            else numbers.RemoveAt(int.Parse(commands[1]));
                            break;
                        }
                    case "Insert":
                        {
                            if (int.Parse(commands[2]) < 0 || int.Parse(commands[2]) >= numbers.Count) Console.WriteLine("Invalid index");
                            else numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                            break;
                        }
                    case "Shift":
                        {
                            
                            if (commands[1] == "left")
                            {
                                for(int i=0; i<int.Parse(commands[2]); i++)
                                {
                                    int move = numbers[0];
                                    numbers.RemoveAt(0);
                                    numbers.Add(move);
                                }
                            }
                            else if(commands[1]== "right")
                            {
                                for (int i = 0; i < int.Parse(commands[2]); i++)
                                {
                                    int move = numbers[numbers.Count-1];
                                    numbers.RemoveAt(numbers.Count-1);
                                    numbers.Insert(0, move);
                                }
                            }
                            break;
                        }
                    default: break;
                }
                foreach (int i in numbers) Console.Write(i + " ");
                Console.WriteLine();
                input = Console.ReadLine();
            }
            foreach (int i in numbers) Console.Write(i + " ");
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
