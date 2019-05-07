using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace associativearrays_homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var letters = new Dictionary<char, int>();
            foreach(char letter in text)
            {
                if (letter!=' ')
                {
                    if (!letters.ContainsKey(letter))
                        letters.Add(letter, 0);
                    letters[letter]++;
                }
            }
            foreach (var el in letters) Console.WriteLine($"{el.Key} -> {el.Value}");
            Console.ReadKey();
        }
    }
}
