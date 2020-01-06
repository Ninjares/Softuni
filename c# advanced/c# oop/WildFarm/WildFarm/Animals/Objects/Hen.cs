using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Hen:Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingsize) :
            base(name, weight, foodEaten, wingsize)
        {
            foodmultiplier = 0.35;
        }

        public override string Sound()
        {
            return "Cluck";
        }

        protected override bool DoIEat(IFood food)
        {
            return true;
        }
    }
}
