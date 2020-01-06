using System;
using System.Collections.Generic;
using System.Text;

namespace RandomClassWork
{
    public class Cat : Mammal, IAnimal
    {
        public Cat() : base()
        {

        }
        public new void Eat()
        {
            Console.WriteLine("Me master, gib food");

        }
    }

    public class Dog : Mammal, IAnimal
    {
        public Dog() : base()
        {

        }
        public override void Eat()
        {
            Console.WriteLine("Danks ma nibba");
        }
    }
}
