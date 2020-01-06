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
                name = "";
                age = 0;
            }

            public Person(string Name, int Age)
            {
                name = Name;
                age = Age;
            }
        }
        static void Main(string[] args)
        {
            Person pesho = new Person("Pesho", 20);
            Person gosho = new Person("Gosho", 18);
            Person stamat = new Person("Stamat", 43);
        }
    }
}
