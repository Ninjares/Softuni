using System;
using System.Collections.Generic;
using System.Linq;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = null;
            p = new Person("Ta", "Surbakov", 5, 20000);
            Console.WriteLine(p);
            p.IncreaseAge(-1);
            Console.WriteLine(p);

        }
    }
}
