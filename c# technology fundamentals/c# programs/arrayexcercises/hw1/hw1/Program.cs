using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            string[] fsplit = first.Split();
            string[] ssplit = second.Split();
            foreach (string rep2 in ssplit)
                foreach (string rep1 in fsplit)
                    if (rep1 == rep2) Console.Write(rep2 + " ");


           // Console.ReadKey();
        }
    }
}
