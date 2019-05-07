using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uprajnenie
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                }
                dictionary[word].Add(synonim);

            }
            Console.WriteLine("-----");
            foreach(var word in dictionary)
            Console.WriteLine(word.Key + " -> " + string.Join(", ", word.Value));
            //vij koda za otpechatvane
            Console.ReadKey();
        }
    }
}
