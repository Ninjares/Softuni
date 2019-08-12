using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritence
{
    class Employee : Person
    {
        public string Company;

        public Employee(string name, string address, string company):base(name, address)
        {
            Company = company;
        }
    }
}
