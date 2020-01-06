using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    class Person
    {
        [MyRequiredAttribute]
        public string FullName { get; private set; }
        [MyRangeAttribute]
        public int Age { get; private set; }
        public Person(string fullname, int age)
        {
            FullName = fullname;
            Age = age;
        }
    }
}
