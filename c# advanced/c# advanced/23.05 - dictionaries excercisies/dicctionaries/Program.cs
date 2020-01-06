using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicctionaries
{
    class Program
    {
        //v-logger

        static int nooffollowing(Dictionary<string,List<string>> vloggers, string name)
        {
            int followees = 0;
            foreach(var vlogger in vloggers)
            {
                if (vlogger.Value.Contains(name)) followees++;
            }
            return followees;
        }
        static void Main(string[] args)
        {
                             //followers
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] commands = input.Split(' ');
                switch (commands[1])
                {
                    case "joined":
                        {
                            if (!vloggers.ContainsKey(commands[0])) vloggers.Add(commands[0], new List<string>());
                            break;
                        }
                    case "followed":
                        {
                            if (vloggers.ContainsKey(commands[0]) && vloggers.ContainsKey(commands[2]) && commands[0] != commands[2])
                                if(!vloggers[commands[2]].Contains(commands[0]))
                                    vloggers[commands[2]].Add(commands[0]);
                            break;
                        }

                }
                input = Console.ReadLine();
            }
            vloggers = vloggers.OrderByDescending(x => x.Value.Count).ThenBy(x => nooffollowing(vloggers, x.Key)).
                ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int pos = 1;
            foreach(var vlogger in vloggers)
            {
                vlogger.Value.Sort();
                Console.WriteLine($"{pos}. {vlogger.Key} : {vlogger.Value.Count} followers, {nooffollowing(vloggers, vlogger.Key)} following");
                if (pos == 1) foreach (string follower in vlogger.Value) Console.WriteLine($"*  {follower}");
                pos++;
            }
                   
            Console.ReadKey();
        }
    }
}
