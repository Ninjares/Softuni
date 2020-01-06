using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Cat:Feline
    {
        public Cat(string name, double weight, int foodeaten, string livingregion, string breed)
            :base(name, weight, foodeaten, livingregion, breed)
        {
            foodmultiplier = 0.3;
        }

        public override string Sound()
        {
            return "Meow";
        }

        protected override bool DoIEat(IFood food)
        {
            return food is Meat || food is Vegetable;
        }
    }
}
