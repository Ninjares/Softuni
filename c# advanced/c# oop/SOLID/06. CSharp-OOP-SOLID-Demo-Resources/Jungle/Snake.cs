using System;
using System.Collections.Generic;
using System.Text;

namespace Jungle
{
    class Snake : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("HAS");
        }

        public override void Jump()
        {
            throw new NotImplementedException();
        }

        public override void Sleep()
        {
            Console.WriteLine("Never sleeps");
        }
    }
}
