﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog:Animal
    {
        public Dog(string name, int age, string gender):base(name, age, gender)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Frog:Animal
    {
        public Frog(string name, int age, string gender):base(name, age, gender)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}
