using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Owl:Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingsize) :
            base(name, weight, foodEaten, wingsize)
        {
            foodmultiplier = 0.25;
        }

        public override string Sound()
        {
            return "Hoot Hoot";
        }

        protected override bool DoIEat(IFood food)
        {
            return food is Meat;
        }
    }
}
