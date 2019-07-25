using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class SimpleLayout : ILayout
    {
        private const string layout = "{0} - {1} - {2}";
        public string LayoutFormat { get => layout; }
    }
}
