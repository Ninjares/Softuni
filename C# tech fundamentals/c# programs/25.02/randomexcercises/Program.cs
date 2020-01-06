using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace randomexcercises
{
    class Program
    {
        class Dice
        {
            public int Sides { get; set; }
            public string Type { get; set; }
            public int Roll()
            {
                Random yeet = new Random();
                return yeet.Next(Sides)+1;
            }

            public Dice()
            {
                Sides = 6;
                Type = "D6";
            }
            public Dice(int s)
            {
                Sides = s;
                Type = $"D{s}";
            }
        }

        static BigInteger factoriel(int n)
        {
            if (n == 1) return n;
            else return n * factoriel(n - 1);
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                BigInteger result = factoriel(int.Parse(Console.ReadLine())); //use references to add numerics
                Dice diceD6 = new Dice();
                Dice diceD8 = new Dice(8);

                Console.WriteLine(result);
                Console.WriteLine($"{diceD6.Type}: {diceD6.Roll()}  {diceD8.Type}: {diceD8.Roll()}");
                //Console.ReadKey();
            }

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
