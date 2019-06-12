using System;

namespace DefiningClasses
{
    public class StartUp
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

            public Person(int Age):this()
            {
                this.age = Age;
            }

            public Person(string Name, int age):this(age)
            {
                name = Name;
            }
        }
        static void Main(string[] args)
        {
            Person pesho = new Person();
            Person gosho = new Person(18);
            Person stamat = new Person("Stamat", 43);
        }
    }
}