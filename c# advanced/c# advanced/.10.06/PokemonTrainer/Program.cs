using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void checkElement(string element, Dictionary<string, Trainer> trainers)
        {
            foreach(var trainer in trainers)
            {
                if (trainer.Value.ContainsElement(element))
                {
                    trainers[trainer.Key].Badges++;
                }
                else trainers[trainer.Key].Hit();
            }
        }
        static void Main(string[] args)
        {
            string input="";
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] data = input.Split();
                if (!trainers.ContainsKey(data[0])) trainers.Add(data[0], new Trainer(data[0]));
                trainers[data[0]].pokemonCollection.Add(new Pokemon(data[1], data[2], int.Parse(data[3])));
                input = Console.ReadLine();
            }
            input = Console.ReadLine(); //first element
            while (input != "End")
            {
                checkElement(input, trainers);
                input = Console.ReadLine();
            }
            foreach(var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badges} {trainer.Value.pokemonCollection.Count}");
            }

        }
    }
}
