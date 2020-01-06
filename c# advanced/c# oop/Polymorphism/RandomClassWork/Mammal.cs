using System;
using System.Collections.Generic;
using System.Text;

namespace RandomClassWork
{
    public class Mammal:IAnimal
    {
        public virtual void Eat()
        {
            Console.WriteLine("Called from Mammal");
        }
    }
}
