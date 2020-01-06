using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalquest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(' ').ToList();
            string input = Console.ReadLine();
            while (input != "Stop")
            {
                if (input != "Stop")
                {
                    string[] commands = input.Split(' ');

                    switch (commands[0])
                    {
                        case "Delete":
                            {
                                int index = int.Parse(commands[1]) + 1;
                                if (index >= 0 && index < words.Count)
                                    words.RemoveAt(index);
                                break;
                            }
                        case "Swap":
                            {
                                if (words.Contains(commands[1]) && words.Contains(commands[2]))
                                {
                                    int word1index = words.IndexOf(commands[1]);
                                    int word2index = words.IndexOf(commands[2]);
                                    words[word2index] = commands[1];
                                    words[word1index] = commands[2];
                                    
                                }
                                break;
                            }
                        case "Sort":
                            {
                                words.Sort();
                                words.Reverse();
                                break;
                            }
                        case "Replace":
                            {
                                if (words.Contains(commands[2]))
                                {
                                    int wordtoreplaceindex = words.IndexOf(commands[2]);
                                    words[wordtoreplaceindex] = commands[1];
                                }
                                break;
                            }
                        case "Put":
                            {
                                int index = int.Parse(commands[2]) - 1;
                                if (index >= 0 && index <= words.Count)
                                {
                                    words.Insert(index, commands[1]);
                                }
                                break;
                            }
                    }
                }

               // Console.WriteLine(string.Join(" ", words));
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", words));
            //Console.ReadKey();
        }
    }
}
