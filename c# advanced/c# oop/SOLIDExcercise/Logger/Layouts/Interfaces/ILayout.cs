using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    interface ILayout
    {
        string LayoutFormat { get; }
    }
}
