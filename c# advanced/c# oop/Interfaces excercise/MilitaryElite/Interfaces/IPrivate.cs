using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    interface IPrivate:ISoldier
    {
        double Salary { get; set; }
    }
}
