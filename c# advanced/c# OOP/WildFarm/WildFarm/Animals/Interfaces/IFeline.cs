using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    interface IFeline:IMammal
    {
        string Breed { get; set; }
    }
}
