using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        static long x = 0;
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(0, 10000).ToList();
            for (int i = 0; i < 4; i++)
            {
                new Thread(() =>
                {
                    while (numbers.Count > 0)
                    {
                        if(numbers.Count%100==0)
                        Console.WriteLine(numbers.Count);
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                }).Start();
            }
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 8; i++)
            {
                //Increment();
                new Thread(Increment).Start();
            }
            Console.ReadLine();
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            Console.WriteLine(x);
        }

        static object obj = new object();
        public static void Increment()
        {
            for(int i=0; i<5000000; i++)
            {
                lock (obj) //until this is finished do not let any other thread access this piece of code
                {
                    x++;
                }
            }
            Console.WriteLine("Finished");
        }
    }
}
