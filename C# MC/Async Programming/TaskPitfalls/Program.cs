using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskPitfalls
{
    class Program
    {
        static void Main(string[] args)
        {
            long delta = GC.GetTotalMemory(false);
            for (int i=0; i<1000; i++)
            {
                //GetNikiAsync();
                new Thread(GetNiki).Start();
            }
            delta = GC.GetTotalMemory(false) - delta;
            Console.WriteLine(delta);
        }

        static async Task GetNikiAsync()
        {
            
        }

        static void GetNiki()
        {

        }
    }
}
