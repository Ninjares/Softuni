using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class Private:Soldier, IPrivate
    {
        public double Salary { get; set; }

        public Private(string id, string firstname, string lastname, double salary) : base(id, firstname, lastname)
        {
            Salary = salary;
        }
    }
}
