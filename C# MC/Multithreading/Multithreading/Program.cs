using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Multithreadinng
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Started from: " + Thread.CurrentThread.ManagedThreadId);
            //PrintNumbers();
            //new Thread(() => { }).Start(); //ThreadStart - what will this thread start
            //new Thread(PrintNumbers).Start();

            Console.WriteLine("Sequential");
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < 1; i++)
            {
                Primes.CalculatePrimes();
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();

            Console.WriteLine("With Threads:");
            List<Thread> threads = new List<Thread>();
            watch.Start();
            for (int i = 0; i < 3; i++)
            {
                threads.Add(new Thread(Primes.CalculatePrimes));
                threads[i].Start();
            }
            threads.ForEach(t => t.Join());
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            for (int i = 0; i < 16; i++)
            {
                new Thread(PumpX).Start();
            }
            Console.ReadLine();
            Console.WriteLine(x);

        }
        public static void PrintNumbers()
        {
            Console.WriteLine("Printed from: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Printin..");
        }

        static long x = 0;
        static object xlock = new object();
        
        public static void PumpX()
        {
            for(int i=0; i<1000000; i++)
            {
                lock (xlock)
                {
                    x++;
                }
            }
        }
    }

    class Primes
    {
        
        public static void CalculatePrimes()
        {
            for(int i=0; i<10000; i++)
            {
                bool isPrime = true;
                for(int j=2; j<i; j++)
                {
                    if (i % j == 0) { isPrime = false; break; }
                }
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(new System.Diagnostics.StackTrace());
        }
    }
    
}
