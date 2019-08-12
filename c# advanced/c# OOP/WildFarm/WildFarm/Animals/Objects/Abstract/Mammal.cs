using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    abstract class Mammal:Animal, IMammal
    {
        public string LivingRegion { get; set; }
        public Mammal(string name, double weight, int foodEaten, string livingRegion) :
            base(name, weight, foodEaten)
        {
            LivingRegion = livingRegion;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
