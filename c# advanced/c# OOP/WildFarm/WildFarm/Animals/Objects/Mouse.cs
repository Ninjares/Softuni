using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Mouse:Mammal
    {
        public Mouse(string name, double weight, int foodeaten, string livingRegion):
            base(name,weight, foodeaten, livingRegion)
        {
            foodmultiplier = 0.1;
        }
        public override string Sound()
        {
            return "Squeak";
        }

        protected override bool DoIEat(IFood food)
        {
            return food is Vegetable || food is Fruit;
        }
    }
}
