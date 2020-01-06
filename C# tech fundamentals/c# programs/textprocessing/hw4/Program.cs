using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder yeet = new StringBuilder(Console.ReadLine());
            for (int i = 0; i < yeet.Length; i++) yeet[i] += (char)3;
            Console.WriteLine(yeet);
            Console.ReadKey();
        }
    }
}
