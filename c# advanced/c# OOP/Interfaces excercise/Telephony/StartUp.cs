using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();
            foreach(string number in numbers)
            {
                smartphone.Call(number);
            }
            foreach(string website in websites)
            {
                smartphone.Browse(website);
            }
        }
    }
}
