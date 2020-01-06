using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    class Student:Person, IStudent
    {
        public Student(string name, int age)
        {
            Console.WriteLine(name +" - "+ age);
        }

        public void print(string yeet)
        {
            Console.WriteLine("invoke me  " + yeet);
        }
    }
}
