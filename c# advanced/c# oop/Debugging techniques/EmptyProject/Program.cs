using System;
using System.Collections.Generic;
using System.Threading;

namespace EmptyProject
{
    class Program
    {
        //Intellitrace
        static void MyMethod1()
        {
            for(int z=0; z<5; z++)
            {
                Console.WriteLine("tred 1 - " + z);
            }
        }
        static void Main(string[] args)
        {

            Thread thread = new Thread(new ThreadStart(MyMethod1));
            List<int> list = new List<int>();
            int i = 0;
            
            while (true)
            {
                list.Add(i);
                i++;
                if (i % 1000000 == 0) Console.WriteLine(i);
            }
        }
    }
}
