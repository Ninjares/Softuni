using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> partsName = new Dictionary<int, string>();
            partsName.Add(25, "Glass");
            partsName.Add(50, "Aluminium");
            partsName.Add(75, "Lithium");
            partsName.Add(100,"Carbon fiber");
            Dictionary<int, int> partsCount = new Dictionary<int, int>();
            partsCount.Add(25, 0);
            partsCount.Add(50, 0);
            partsCount.Add(75, 0);
            partsCount.Add(100,0);

            int[] chems = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] prts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> chemicals = new Queue<int>(chems);
            Stack<int> parts = new Stack<int>(prts);

            while (parts.Count != 0 && chemicals.Count != 0)
            {
                switch(parts.Peek() + chemicals.Peek())
                {
                    case 25:
                        {
                            partsCount[25]++;
                            parts.Pop();
                            chemicals.Dequeue();
                            break;
                        }
                    case 50:
                        {
                            partsCount[50]++;
                            parts.Pop();
                            chemicals.Dequeue();
                            break;
                        }
                    case 75:
                        {
                            partsCount[75]++;
                            parts.Pop();
                            chemicals.Dequeue();
                            break;
                        }
                    case 100:
                        {
                            partsCount[100]++;
                            parts.Pop();
                            chemicals.Dequeue();
                            break;
                        }
                    default:
                        {
                            chemicals.Dequeue();
                            int currentPart = parts.Pop();
                            currentPart += 3;
                            parts.Push(currentPart);
                            break;
                        }
                }
            }
            bool canBuildSpaceShip = partsCount.All(x => x.Value >= 1);
            if (canBuildSpaceShip) Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            else Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            Console.Write("Liquids left: ");
            if (chemicals.Count == 0) Console.WriteLine("none"); else Console.WriteLine(string.Join(", ", chemicals));
            Console.Write("Physical items left: ");
            if (parts.Count == 0) Console.WriteLine("none"); else Console.WriteLine(string.Join(", ", parts));
            foreach(var part in partsName.OrderBy(x => x.Value))
            {
                Console.WriteLine($"{part.Value}: {partsCount[part.Key]}");
            }
        }
    }
}
