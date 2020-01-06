using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> pokemonCollection;

        public bool ContainsElement(string element)
        {
            foreach (var pokemon in pokemonCollection)
                if (element == pokemon.Element) return true;
            return false;
        }

        public void Hit()
        {
            for(int i=0; i<pokemonCollection.Count; i++)
            {
                pokemonCollection[i].Health -= 10;
            }
            for (int i = 0; i < pokemonCollection.Count; i++)
            {
                if (pokemonCollection[i].Health <= 0) { pokemonCollection.RemoveAt(i); i--; }
            }
        }
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            pokemonCollection = new List<Pokemon>();
        }
    }
    class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
        
        public bool isElement(string Element)
        {
            return this.Element == Element;
        }
        public Pokemon(string name, string element, int HP)
        {
            Name = name;
            Element = element;
            Health = HP;
        }
    }
}
