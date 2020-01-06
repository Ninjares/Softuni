using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firsthand     = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondhand    = Console.ReadLine().Split().Select(int.Parse).ToList();
            

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
