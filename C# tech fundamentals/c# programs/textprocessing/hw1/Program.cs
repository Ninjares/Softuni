using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] names = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            string regex = "\\w+[-_]";
            foreach (string name in names)
            {
                if (name.Length > 2 && name.Length < 17)
                {
                    MatchCollection match = Regex.Matches(name, regex);
                    Console.WriteLine(match[0]);
                }
            }
            

            Console.ReadKey();

        }
    }
}
