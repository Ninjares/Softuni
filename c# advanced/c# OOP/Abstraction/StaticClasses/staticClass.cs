using System;
using System.Collections.Generic;
using System.Text;

namespace StaticClasses
{
    public static class staticClass
    {
        public static void Print()
        {
            Console.WriteLine("I am undeclared and I can only be used undeclared");
        }
        static staticClass()
        {

        }
    }
}
