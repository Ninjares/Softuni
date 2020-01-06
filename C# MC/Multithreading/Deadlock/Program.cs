using System;
using System.Threading;

namespace Deadlock
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(DeadLock).Start();
            new Thread(DeadLock2).Start();
        }

        static object xlock = new object();
        static object ylock = new object();

        public static void DeadLock()
        {
            lock (xlock)
            {
                Console.WriteLine("In X");
                Thread.Sleep(1000);
                lock (ylock)
                {
                    Console.WriteLine("in Y");
                }
            }
        }

        public static void DeadLock2()
        {
            lock (ylock)
            {
                Console.WriteLine("In Y");
                Thread.Sleep(1000);
                lock (xlock)
                {
                    Console.WriteLine("in X");
                }
            }
        }
    }
}
