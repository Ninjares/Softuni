using System;
using System.Threading;

namespace ThreadPol
{
    class Program
    {
        //new Thread() is foreground by default and all threads in ThreadPool are background
        static void Main(string[] args)
        {
            new Thread(Print).Start();

            ThreadPool.QueueUserWorkItem((object obj) => 
            { 
                Print(); 
            });
        }

        static void ThreadInfo()
        {
            int max, sth;
            ThreadPool.GetAvailableThreads(out max, out sth);
            Console.WriteLine("Available Threads: " + max);
            ThreadPool.GetMinThreads(out max, out sth);
            Console.WriteLine("Available Threads: " + max);
            ThreadPool.GetMaxThreads(out max, out sth);
            Console.WriteLine("Available Threads: " + max);
        }

        public static void Print()
        {
            for(int i=0; i<10; i++)
            {
                Console.WriteLine(i + 1);
            }
        }
        public static void CalculatePrimes(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0) { isPrime = false; break; }
                }
            }
        }

    }
}
