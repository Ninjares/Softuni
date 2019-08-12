using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat:Animal
    {
        
        public Cat(string name, int age, string gender):base(name, age, gender)
        {
            
        }

        public void ProduceSound()
        {
            Console.WriteLine("Meow meow");
        }
    }

    public class Kitten : Cat
    {
        private const string gender = "Female";
        public Kitten(string name, int age) : base(name, age, gender)
        {

        }
        public new void ProduceSound()
        {
            Console.WriteLine("meow");
        }
    }
    public class Tomcat : Cat
    {
        private const string gender = "Male";
        public Tomcat(string name, int age) : base(name, age, gender)
        {

        }
        public new void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
