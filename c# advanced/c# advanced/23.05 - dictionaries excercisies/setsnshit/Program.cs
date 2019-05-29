using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace setsnshit
{
    class Program
    {
        static void Main(string[] args)
        {
            int entries = int.Parse(Console.ReadLine());
            var clothes = new Dictionary<string, Dictionary<string, int>>();

            while (entries != 0)
            {
                string[] colorclothes = Console.ReadLine().Split(new string[] { " -> " }, StringSplitOptions.None);
                string[] clotheslist = colorclothes[1].Split(',');
                string color = colorclothes[0];

                if (!clothes.ContainsKey(color)) clothes.Add(color, new Dictionary<string, int>());
                foreach (string clothing in clotheslist)
                {
                    if (!clothes[color].ContainsKey(clothing)) clothes[color].Add(clothing, 1);
                    else clothes[color][clothing]++;
                }
                entries--;
            }

            string[] search = Console.ReadLine().Split();
            foreach(var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach(var setofclothes in color.Value)
                {
                    Console.Write($"* {setofclothes.Key} - {setofclothes.Value}");
                    if (search[0] == color.Key && search[1] == setofclothes.Key) Console.Write(" (found!)");
                    Console.WriteLine();
                }

            }

            Console.ReadKey();
        }
    }
}
