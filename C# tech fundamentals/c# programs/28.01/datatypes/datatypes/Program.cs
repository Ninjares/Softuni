using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datatypes
{
    class Program
    {
        static int ars = 3;
        static void Main(string[] args)
        {
            int [] array = new int[ars];
            for(int i=0; i<ars; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < ars; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.ReadKey();
        }
    }
}
