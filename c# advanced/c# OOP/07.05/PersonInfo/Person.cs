using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        //protected - can be accessed by inhereted classes
    }
}
