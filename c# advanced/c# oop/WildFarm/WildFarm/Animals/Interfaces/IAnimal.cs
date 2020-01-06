using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public interface IAnimal
    {
        string Name { get; set; }
        double Weight { get; set; }
        int FoodEaten { get; set; }
        string Sound();

        void Eat(IFood food);
    }
}
