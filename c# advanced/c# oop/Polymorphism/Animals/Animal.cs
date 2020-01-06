using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    abstract class Animal //Abstract classes cannot be initialized
    {
        public string name;
        public string favoriteFood;

        protected Animal(string name, string food)
        {
            this.name = name;
            favoriteFood = food;
        }
        public virtual string ExplainSelf()
        {
            return $"I am {name} and my favourite food is {favoriteFood}";
        }
    }
}
