using System;
using System.IO;

namespace Line_numbers
{
    class Program
    {
        static int numberofletters(string a)
        {
            int letters = 0;
            foreach(char c in a)
            {
                if ((c > 64 && c < 91) || (c > 96 && c < 123)) letters++;
            }
            return letters;
        }
        static int numberofpuncts(string a)
        {
            int letters = 0;
            foreach (char c in a)
            {
                if (c=='.'||c=='-'||c==','||c=='!'||c=='?') letters++;
            }
            return letters;
        }
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\..\Text\input.txt");
            using (reader)
            {
                string text = reader.ReadLine();
                using(var writer = new StreamWriter(@"..\..\..\Text\output.txt"))
                {
                    int line = 1;
                    while (text != null)
                    {
                        
                        int letters = numberofletters(text);
                        int punctmartks = numberofpuncts(text);
                        writer.WriteLine($"Line {line}: {text} ({letters})({punctmartks})");
                        text = reader.ReadLine();
                        line++;
                    }
                }
            }
        }
    }
}
