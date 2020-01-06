using System;
using System.Threading;
using System.Threading.Tasks;

namespace LongRunning
{
    class Program
    {
        static void Main(string[] args)
        {
            
            for (int i=0; i<100; i++)
            {
                Task.Run(DoLongWork); //Uses the threadpool
            }
        }

        static void DoLongWork()
        {
            Console.WriteLine("Start - "+ Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(20000);
            Console.WriteLine("End - " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
