using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomexc
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello";
            //text[0] = 'A';    - can't use, because it's read only

            Console.WriteLine(text[0]);
            
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
