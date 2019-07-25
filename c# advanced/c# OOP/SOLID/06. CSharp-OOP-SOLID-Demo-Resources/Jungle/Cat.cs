using System;
using System.Collections.Generic;
using System.Text;

namespace Jungle
{
    class Cat : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Qm");
        }

        public override void Jump()
        {
            Console.WriteLine("bong");
        }

        public override void Sleep()
        {
            Console.WriteLine("Zzzzz");
        }
    }
}
