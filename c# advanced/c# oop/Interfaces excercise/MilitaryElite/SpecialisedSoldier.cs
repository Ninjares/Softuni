using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class SpecialisedSoldier : Private
    {
        public Corps Corp {get; set;}
        
        public SpecialisedSoldier(string id, string firstname, string lastname, double salary, Corps corp) : base(id, firstname, lastname, salary)
        {
            Corp = corp;
        }
    }
}
