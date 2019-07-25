using System;
using System.Collections.Generic;
using System.Text;

namespace Jungle
{
    public abstract class Animal
    {
        //this is wrong
        //public void Sleep()
        //{
        //    if (this is Snake)
        //    {
        //        Console.WriteLine("Das a lie");
        //    }
        //    else Console.WriteLine("zzzzzz");
        //}
        public abstract void Sleep();
        public abstract void Jump();
        public abstract void Eat();
    }
}
