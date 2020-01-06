using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Programming
{
    class Program
    {
        //await & async
        //Task.Run by default is background by default
        static void Main(string[] args)
        {
            Task task = DoWorkAsync();
            Task newtask = new Task(DoWork);
            task.ConfigureAwait(false);
            Console.WriteLine(GetAsync().Result);
            Console.ReadKey();
        }

        static public void BasicShit()
        {
            Task.Run((Action)Hello);
            Task.Run(() => Console.WriteLine("yu bumpa"));
            Task task = new Task(() => { Console.WriteLine("ya bompa"); });
            task.Wait();
            int a = Task<int>.Run(() => { return 5; }).Result;
            task.RunSynchronously();
        }


        static async void Hello()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hi");
        }

        static async void DoWork()
        {
            Console.WriteLine("DW thread: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
        }

        static async Task DoWorkAsync()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - 0/2");
            await Task.Run(DoWork);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - 1/2");
            Thread.Sleep(2000);
            Console.WriteLine("2/2");
        }

        static async Task<string> GetAsync()
            {
            await Task.Delay(1000);
            return "Delivery done";
        }
    }
}
