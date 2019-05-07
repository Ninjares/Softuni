using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods_with_vars
{
    class Program
    {
        static void printmeme(string meme)
        {
            Console.WriteLine(meme);
        }
        static string readmeme()
        {
            string inp = Console.ReadLine();
            return inp;
        }

        static void fromto(int start, int end)
        {
            for(int i=start; i<=end; i++)
                print(i.ToString(), (ConsoleColor)(i % 16));
        }

        static void print(string inp, ConsoleColor col)
        {
            Console.WriteLine(inp, col);
        }

        static void printtriangle(int stage, int bottom)
        {
            for (int i = 1; i <= stage; i++) Console.Write(i+" ");
            Console.WriteLine();
            if (stage < bottom) printtriangle(stage + 1, bottom);
            if (stage != bottom)
            {
                for (int i = 1; i <= stage; i++) Console.Write(i + " ");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            
           // printmeme(readmeme());
           // fromto(0, 100);
            Console.WriteLine("a", ConsoleColor.Cyan);
            printtriangle(1, 4);
            Console.ReadKey();
        }
    }
}
