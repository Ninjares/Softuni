using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    interface Car
    {
        void Brakes();
        void Gas();
        string Driver { get; set; }
    }
}
