using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { this.age = value; }
        }

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int Age) : this()
        {
            age = Age;
        }

        public Person(string Name, int Age) : this(Age)
        {
            name = Name;
        }
    }
}
