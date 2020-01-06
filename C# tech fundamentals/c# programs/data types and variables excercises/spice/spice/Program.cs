using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spice
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0, totalspice = 0;
            while (yield >= 100)
            {
                totalspice += yield;
                yield -= 10;
                days++;
                totalspice -= 26;
               // Console.WriteLine("end of day {0}: total {1}   yield: {2}", days, totalspice, yield);
            }

            if(days!=0) totalspice -= 26;
            Console.WriteLine(days + "\n"+ totalspice);
            Console.ReadKey();
        }
    }
}
