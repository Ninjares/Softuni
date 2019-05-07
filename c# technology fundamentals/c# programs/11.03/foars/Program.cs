using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foars
{
    class Program
    {
        static void Main(string[] args)
        {
            //jedi - k; force - v
            var jedis = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                string[] jeb0i;
                if (input.Contains("->"))
                {
                    //jedi -> force
                    jeb0i = input.Split(new string[] { " -> " }, StringSplitOptions.None);
                    if (!jedis.ContainsKey(jeb0i[0])) jedis.Add(jeb0i[0], jeb0i[1]);
                    else jedis[jeb0i[0]] = jeb0i[1];
                    Console.WriteLine($"{jeb0i[0]} joins the {jeb0i[1]} side!");
                    
                }
                else if (input.Contains('|'))
                {
                    //force | jedi
                    jeb0i = input.Split(new string[] { " | " }, StringSplitOptions.None);
                    if (!jedis.ContainsKey(jeb0i[1])) jedis.Add(jeb0i[1], jeb0i[0]);
                }
                input = Console.ReadLine();
            }
                                    //jedis
            Dictionary<string, List<string>> forces = new Dictionary<string, List<string>>();
            foreach (var jedi in jedis) if (!forces.ContainsKey(jedi.Value)) forces.Add(jedi.Value, new List<string>());
            foreach (var jedi in jedis) if (!forces[jedi.Value].Contains(jedi.Key)) forces[jedi.Value].Add(jedi.Key);

            foreach (var force in forces) force.Value.Sort();
            forces = forces.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var force in forces)
            {
                Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
                foreach (string boi in force.Value) Console.WriteLine($"! {boi}");
            }

            Console.ReadKey();
        }
    }
}
