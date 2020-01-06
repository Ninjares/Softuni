using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    abstract class Animal:IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = FoodEaten;
        }

        public abstract string Sound();

        public void Eat(IFood food)
        {
            if (DoIEat(food))
            {
                Weight += food.Quantity * foodmultiplier;
                FoodEaten += food.Quantity;
            }
            else throw new Exception($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        protected abstract bool DoIEat(IFood food);

        protected double foodmultiplier { get; set; }
    }
}
