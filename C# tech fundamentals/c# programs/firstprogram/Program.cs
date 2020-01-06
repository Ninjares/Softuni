using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Meme machine";
            var x = int.Parse(Console.ReadLine());
            string meme = Console.ReadLine();
            Console.WriteLine("Hello {0} \n{1}", meme, x*2);  //+ works too

            //           File.WriteAllLines("succ.txt", meme, Encoding.UTF32);
            double y = 2.5378;
            Console.WriteLine("{0:F2}", y);
            Console.WriteLine($"{meme} {x:F3}");
            Console.WriteLine(1 > 2);
            Console.WriteLine(1 < 2);
            Console.ReadKey();
            int i = 0;
            while (true)
            {
                Console.WriteLine(i);
                i++;
                //continue; the opposite of break - look it up
            }
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
