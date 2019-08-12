using System;

namespace RhombusOfStars
{
    class Program
    {
        static void printLine(int n, int stage)
        {
            for (int i = 0; i < n - stage; i++) Console.Write(' ');
            for (int i = 0; i < stage - 1; i++) Console.Write("* ");
            Console.Write('*');
            Console.WriteLine();
        }
        static void rhomb (int n, int stage)
        {
            printLine(n, stage);
            
            if (n != stage)
            {
                rhomb(n, stage + 1);
                printLine(n, stage);
            }
            
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if(n>0)
            rhomb(n, 1);

        }
    }
}
