using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Paralle
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Enumerable.Range(0,1000).ToList();
            var partitioner = Partitioner.Create(0, list.Count);
            Stopwatch wath = Stopwatch.StartNew();
            foreach(var item in list)
            {
                var num = item;
            }
            wath.Stop();
            Console.WriteLine(wath.Elapsed);
            wath.Reset(); 
            wath.Start();
            Parallel.ForEach(list, (el) =>
            {
                var item = el;
            });
            wath.Stop();
            Console.WriteLine(wath.Elapsed);

        }
    }
}
