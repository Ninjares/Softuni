using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age):base(null, 0)//Can't have a constructor without the base
        {
            this.Age = age;
        }

        public int Age
        {
            get => base.Age;
            set
            {
                if (value <= 15) base.Age = value;
            }
        }
    }
}
