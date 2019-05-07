using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace int_ops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n =  int.Parse(Console.ReadLine());
            int p =  int.Parse(Console.ReadLine());
            int trips = n/p;
            
            if (n%p!=0) trips++;
            Console.WriteLine(trips);
            Console.ReadKey();
        }
    }
}
