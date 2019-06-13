using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            var yeet = new DateModifier(firstDate, secondDate);
            Console.WriteLine(yeet.returnDiff());
        }
    }
}
