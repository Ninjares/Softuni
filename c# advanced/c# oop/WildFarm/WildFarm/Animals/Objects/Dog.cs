using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Dog:Mammal
    {
        public Dog(string name, double weight, int foodeaten, string livingRegion) :
            base(name, weight, foodeaten, livingRegion)
        {
            foodmultiplier = 0.4;
        }
        public override string Sound()
        {
            return "Woof!";
        }

        protected override bool DoIEat(IFood food)
        {
            return food is Meat;
        }
    }
}
