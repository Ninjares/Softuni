using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    class Person
    {
        private int age;
        private string firstname;
        public string FirstName
        {
            get => firstname;
            set
            {
                if (value.Length < 3) throw new ArgumentException("Name is too short");
                firstname = value;
            }
        }
        public string LastName { get; set; }
        public int Age {
            get => age;
            private set
            {
                if (value < 0) throw new ArgumentException("Invalid age");
                else this.age = value;
            }
        }
        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }

        public void IncreaseAge(int toAdd)
        {
            if (toAdd < 0) throw new ArgumentException("Can't make younger");
            Age += toAdd;
        }

        public Person(string fname, string lname, int age, decimal salary)
        {
            FirstName = fname;
            LastName = lname;
            Age = age;
            Salary = salary;
        }
    }
}
