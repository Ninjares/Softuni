using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    enum FlourType
    {
        White, Wholegrain
    }
    enum BakingTechnique
    {
        Crispy, Chewy, Homemade
    }
    class Dough
    {
        private int weight;
        private int Weight { get => weight;
            set
            {
                if (value < 1 || value > 200) { Console.WriteLine("Dough weight should be in the range [1..200]"); Environment.Exit(0); }
                else weight = value;
            }
        }
        private FlourType flour;
        private BakingTechnique technique;
        public decimal Calories
        {
            get
            {
                decimal cals = weight*2;
                switch (flour)
                {
                    case FlourType.White:
                        {
                            cals *= 1.5m;
                            break;
                        }
                    case FlourType.Wholegrain:
                        {
                            cals *= 1.0m;
                            break;
                        }
                }
                switch (technique)
                {
                    case BakingTechnique.Chewy:
                        {
                        cals *= 1.1m;
                        break;
                        }
                    case BakingTechnique.Crispy:
                        {
                            cals *= 0.9m;
                            break;
                        }

                    case BakingTechnique.Homemade:
                        {
                            cals *= 1.0m;
                            break;
                        }
                }
                return cals;
            }
        }

        public Dough(int weight, string flour, string technique)
        {
            Weight = weight;
            switch (flour.ToLower())
            {
                case "white": { this.flour=FlourType.White ;break; }
                case "wholegrain": { this.flour = FlourType.Wholegrain; break; }
                default: { Console.WriteLine("Invalid type of dough."); Environment.Exit(0); break; }
            }
            switch (technique.ToLower())
            {
                case "crispy": { this.technique = BakingTechnique.Crispy; break; }
                case "chewy": { this.technique = BakingTechnique.Chewy; break; }
                case "homemade": { this.technique = BakingTechnique.Homemade; break; }
                default: { Console.WriteLine("Invalid type of dough."); Environment.Exit(0); break; }
            }
        }
    }
}
