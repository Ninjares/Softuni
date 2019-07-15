using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Cat:Animal
    {
        public Cat(string name, string food):base(name, food)
        {

        }

        //overload vs override (ocerriding replaces the old class with the new one)/(overloading is same name different parameters)
        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()}\nMEEOW";
        }
        
    }

    class Dog:Animal
    {
        public Dog(string name, string food):base(name, food)
        {

        }

        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()}\nDJAAF";
        }
    }
}
