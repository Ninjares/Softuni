using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    class Tiger:Feline
    {
        public Tiger(string name, double weight, int foodeaten, string livingregion, string breed)
            : base(name, weight, foodeaten, livingregion, breed)
        {
            foodmultiplier = 1d;
        }

        public override string Sound()
        {
            return "ROAR!!!";
        }

        protected override bool DoIEat(IFood food)
        {
            return food is Meat;
        }
    }
}
