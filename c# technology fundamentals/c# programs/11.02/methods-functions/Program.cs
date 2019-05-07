using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods_functions
{
    class Program
    {
        static string meme;

        static void printmeme()
        {
            Console.WriteLine(meme);
        }

        static string readmeme()
        {
            meme = Console.ReadLine();
            return meme;
        }


        static void Main(string[] args)
        {
            readmeme();
            printmeme();
            Console.ReadKey();
        }
    }
}
