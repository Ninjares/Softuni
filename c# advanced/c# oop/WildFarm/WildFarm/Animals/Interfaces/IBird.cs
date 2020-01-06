using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    interface IBird:IAnimal
    {
        double WingSize { get; set; }
    }
}
