using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            StreamReader reader = new StreamReader(@"..\..\Text\input.txt");
            using (reader)
            {
                int even = 0;
                using(var writer = new StreamWriter(@"..\..\Text\output.txt"))
                {
                    text = reader.ReadLine();
                    while (text != null)
                    {
                        if (even % 2 == 0)
                        {
                            string[] words = text.Split().Reverse().ToArray();
                            StringBuilder sb = new StringBuilder(string.Join(" ", words));
                            sb.Replace('-', '@');
                            sb.Replace(',', '@');
                            sb.Replace('.', '@');
                            sb.Replace('!', '@');
                            sb.Replace('?', '@');
                            Console.WriteLine(sb);
                            writer.WriteLine(sb);
                        }
                        even++;
                        text = reader.ReadLine();
                    }
                }
            }
            Console.ReadKey();

        }
    }
}
