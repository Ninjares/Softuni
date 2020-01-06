using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int nplayers = int.Parse(Console.ReadLine());
            decimal energy = decimal.Parse(Console.ReadLine());
            decimal waterperday = decimal.Parse(Console.ReadLine());
            decimal foodperday = decimal.Parse(Console.ReadLine());
            int currentday = 1;
            decimal totalwater = waterperday * days * nplayers;
            decimal totalfood = foodperday * days * nplayers;

            while (currentday <= days)
            {
                energy -= decimal.Parse(Console.ReadLine()); //energy spent on chopping wood
                if (energy > 0)
                {

                    if ((currentday) % 2 == 0)
                    {

                        //drincc water
                        energy *= 1.05m;
                        totalwater *= 0.7m;
                    }
                    if ((currentday) % 3 == 0)
                    {
                        //omnomnom
                        energy *= 1.1m;
                        totalfood -= totalfood / nplayers;
                    }
                }
                else break;
                // Console.WriteLine(energy);
                // Console.WriteLine("water: "+totalwater+"\nfood: " + totalfood);
                currentday++;
            }
            if (energy > 0) Console.WriteLine($"You are ready for the quest. You will be left with - {energy:F2} energy!");
            else Console.WriteLine($"You will run out of energy. You will be left with {totalfood:F2} food and {totalwater:F2} water.");
            // Console.ReadKey();
        }
    }
}