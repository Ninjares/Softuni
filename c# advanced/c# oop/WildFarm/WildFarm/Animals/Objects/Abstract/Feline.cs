using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    abstract class Feline:Mammal, IFeline
    {
        public string Breed { get; set; }

        public Feline(string name, double weight, int foodEaten, string livingRegion, string breed):
            base(name, weight, foodEaten, livingRegion)
        {
            Breed = breed;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
